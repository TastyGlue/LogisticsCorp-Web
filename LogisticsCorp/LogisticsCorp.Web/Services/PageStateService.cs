namespace LogisticsCorp.Web.Services;

/// <summary>
/// Service for managing page-level state such as page title and subtitle.
/// Pages can inject this service to set their title and subtitle dynamically.
/// </summary>
public class PageStateService
{
    private string _pageTitle = string.Empty;
    private string _pageSubtitle = string.Empty;

    public string PageTitle
    {
        get => _pageTitle;
        set
        {
            if (_pageTitle != value)
            {
                _pageTitle = value;
                NotifyStateChanged();
            }
        }
    }

    public string PageSubtitle
    {
        get => _pageSubtitle;
        set
        {
            if (_pageSubtitle != value)
            {
                _pageSubtitle = value;
                NotifyStateChanged();
            }
        }
    }

    public event Action? OnChange;

    /// <summary>
    /// Sets both the page title and subtitle in one call.
    /// </summary>
    public void SetPageInfo(string title, string subtitle)
    {
        _pageTitle = title;
        _pageSubtitle = subtitle;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
