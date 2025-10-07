﻿using System.Text.Json.Serialization;

namespace LogisticsCorp.Shared.Models;

/// <summary>
/// Represents an error result containing details about an error that occurred during an operation.
/// </summary>
public class ErrorResult
{
    /// <summary>
    /// Gets or sets a human-readable message.
    /// </summary>
    public string Message { get; set; } = default!;

    /// <summary>
    /// Gets or sets the application-specific error code associated with the current operation.
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional details, such as validation error messages.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string> Details { get; set; } = default!;

    public ErrorResult(string message, string? errorCode = null, List<string> details = null!)
    {
        Message = message;
        ErrorCode = errorCode;
        Details = details ?? [];
    }
}
