﻿using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;

namespace LogisticsCorp.Shared.Utils;

public static class Utils
{
    private static readonly JsonSerializerOptions _caseInsensitiveOptions = new() { PropertyNameCaseInsensitive = true };

    public static List<T> ReadJsonDataFile<T>(string filePath) where T : class
    {
        filePath = Path.Combine(AppContext.BaseDirectory, filePath);

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"The file '{filePath}' was not found.");

        var jsonData = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<T>>(jsonData, _caseInsensitiveOptions) 
               ?? throw new InvalidOperationException($"Failed to deserialize data from file '{filePath}'.");
    }

    public static string GetFullExceptionMessage(Exception ex)
    {
        if (ex == null) return string.Empty;

        var errorMessage = new StringBuilder();
        errorMessage.AppendLine($"Exception: {ex.Message}");
        errorMessage.AppendLine($"Stack Trace: {ex.StackTrace}");

        var innerException = ex.InnerException;
        while (innerException != null)
        {
            errorMessage.AppendLine("---- Inner Exception ----");
            errorMessage.AppendLine($"Exception: {innerException.Message}");
            errorMessage.AppendLine($"Stack Trace: {innerException.StackTrace}");
            innerException = innerException.InnerException;
        }

        return errorMessage.ToString();
    }

    public static bool LooksLikeJson(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return false;

        content = content.Trim();

        return (content.StartsWith('{') && content.EndsWith('}')) ||
               (content.StartsWith('[') && content.EndsWith(']')) ||
               (content.StartsWith('\"') && content.EndsWith('\"'));
    }

    public static ErrorResult GetErrorMessageFromException(this Exception ex, bool isDeleteRequest = false)
    {
        if (ex is DbUpdateException dbEx)
        {
            if (dbEx.InnerException is PostgresException pgEx)
            {
                switch (pgEx.SqlState)
                {
                    case PostgresErrorCodes.UniqueViolation:
                        var indexViolationMessage = GetIndexViolationMessage(pgEx.ConstraintName);

                        return new(indexViolationMessage ?? "This data already exists", ErrorCodes.DB_UNIQUE_VIOLATION);
                    case PostgresErrorCodes.ForeignKeyViolation:
                        var errorMessage = isDeleteRequest
                            ? "Cannot delete this item because it is referenced by other data"
                            : "Referenced data not found or invalid foreign key";

                        return new(errorMessage, ErrorCodes.DB_FOREIGN_KEY_VIOLATION);
                    case PostgresErrorCodes.NotNullViolation:
                        return new("Required field is missing", ErrorCodes.DB_NOT_NULL_VIOLATION);
                    default:
                        return new("An unexpected database error occurred", ErrorCodes.DB_UNEXPECTED_ERROR);
                }
            }
            else
                return new("An unexpected database error occurred", ErrorCodes.DB_UNEXPECTED_ERROR);
        }
        else if (ex is ArgumentException)
        {
            return new(ex.Message, ErrorCodes.API_INVALID_ARGUMENT);
        }
        else
        {
            return new("An unexpected error occurred", ErrorCodes.API_UNEXPECTED_ERROR);
        }
    }

    private static string? GetIndexViolationMessage(string? constraintName)
    {
        if (string.IsNullOrWhiteSpace(constraintName))
            return null;

        var indexViolation = IndexConstants.IndexViolations
            .FirstOrDefault(iv => iv.IndexName.Equals(constraintName, StringComparison.OrdinalIgnoreCase));

        return indexViolation?.ErrorMessage;
    }
}