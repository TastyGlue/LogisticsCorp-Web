namespace LogisticsCorp.Web.Components.Abstract;

public static class Themes
{
    public static readonly MudTheme DefaultTheme = new()
    {
        PaletteDark = new()
        {
            // Primary yellow theme
            Primary = "#FFD700",
            PrimaryDarken = "#FFC700",
            PrimaryLighten = "#FFED4E",

            // Secondary colors
            Secondary = "#424242",
            Tertiary = "#A78BFA",

            // Background colors
            Background = "#0F0F0F",
            BackgroundGray = "#151515",
            Surface = "#1A1A1A",

            // AppBar and Drawer
            AppbarBackground = "#1A1A1A",
            DrawerBackground = "#1A1A1A",

            // Text colors
            TextPrimary = "#E8E8E8",
            TextSecondary = "#A0A0A0",
            TextDisabled = "#707070",

            // Action colors
            ActionDefault = "#E8E8E8",
            ActionDisabled = "#707070",
            ActionDisabledBackground = "#2A2A2A",

            // Divider
            Divider = "#2A2A2A",
            DividerLight = "#353535",

            // Status colors
            Success = "#34D399",
            Warning = "#FFC700",
            Error = "#F87171",
            Info = "#60A5FA",

            // Hover states
            HoverOpacity = 0.06,

            // Lines and borders
            LinesDefault = "#2A2A2A",
            LinesInputs = "#2A2A2A"
        },

        LayoutProperties = new()
        {
            DefaultBorderRadius = "8px",
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "260px",
            DrawerMiniWidthLeft = "56px",
            DrawerMiniWidthRight = "56px",
            AppbarHeight = "64px"
        },

        Typography = new()
        {
            Default = new DefaultTypography()
            {
                FontFamily = ["-apple-system", "BlinkMacSystemFont", "Segoe UI", "Roboto", "Helvetica Neue", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = "400",
                LineHeight = "1.5",
                LetterSpacing = "normal"
            },
            H1 = new H1Typography()
            {
                FontSize = "3rem",
                FontWeight = "700",
                LineHeight = "1.167",
                LetterSpacing = "-0.01em"
            },
            H2 = new H2Typography()
            {
                FontSize = "1.875rem",
                FontWeight = "700",
                LineHeight = "1.2",
                LetterSpacing = "normal"
            },
            H3 = new H3Typography()
            {
                FontSize = "1.5rem",
                FontWeight = "700",
                LineHeight = "1.167",
                LetterSpacing = "0"
            },
            H4 = new H4Typography()
            {
                FontSize = "1.25rem",
                FontWeight = "600",
                LineHeight = "1.235",
                LetterSpacing = "normal"
            },
            H5 = new H5Typography()
            {
                FontSize = "1.125rem",
                FontWeight = "600",
                LineHeight = "1.334",
                LetterSpacing = "0"
            },
            H6 = new H6Typography()
            {
                FontSize = "1rem",
                FontWeight = "600",
                LineHeight = "1.6",
                LetterSpacing = "normal"
            },
            Subtitle1 = new Subtitle1Typography()
            {
                FontSize = "1rem",
                FontWeight = "500",
                LineHeight = "1.75",
                LetterSpacing = "normal"
            },
            Subtitle2 = new Subtitle2Typography()
            {
                FontSize = "0.875rem",
                FontWeight = "500",
                LineHeight = "1.57",
                LetterSpacing = "normal"
            },
            Body1 = new Body1Typography()
            {
                FontSize = "1rem",
                FontWeight = "400",
                LineHeight = "1.5",
                LetterSpacing = "normal"
            },
            Body2 = new Body2Typography()
            {
                FontSize = "0.875rem",
                FontWeight = "400",
                LineHeight = "1.43",
                LetterSpacing = "normal"
            },
            Button = new ButtonTypography()
            {
                FontSize = "0.875rem",
                FontWeight = "500",
                LineHeight = "1.75",
                LetterSpacing = "0.02857em",
                TextTransform = "uppercase"
            },
            Caption = new CaptionTypography()
            {
                FontSize = "0.75rem",
                FontWeight = "400",
                LineHeight = "1.66",
                LetterSpacing = "normal"
            },
            Overline = new OverlineTypography()
            {
                FontSize = "0.75rem",
                FontWeight = "600",
                LineHeight = "2.66",
                LetterSpacing = "0.08333em",
                TextTransform = "uppercase"
            }
        },

        ZIndex = new()
        {
            Drawer = 1100,
            AppBar = 1300,
            Dialog = 1400,
            Popover = 1200,
            Snackbar = 1500,
            Tooltip = 1600
        },

        Shadows = new()
        {
            Elevation =
            [
                "none",
                "0 1px 2px rgba(0, 0, 0, 0.5)",
                "0 2px 4px rgba(0, 0, 0, 0.5)",
                "0 4px 6px rgba(0, 0, 0, 0.5)",
                "0 6px 8px rgba(0, 0, 0, 0.5)",
                "0 8px 10px rgba(0, 0, 0, 0.5)",
                "0 10px 15px rgba(0, 0, 0, 0.6)",
                "0 12px 17px rgba(0, 0, 0, 0.6)",
                "0 14px 19px rgba(0, 0, 0, 0.6)",
                "0 16px 21px rgba(0, 0, 0, 0.6)",
                "0 18px 23px rgba(0, 0, 0, 0.6)",
                "0 20px 25px rgba(0, 0, 0, 0.6)",
                "0 22px 27px rgba(0, 0, 0, 0.6)",
                "0 24px 29px rgba(0, 0, 0, 0.6)",
                "0 26px 31px rgba(0, 0, 0, 0.6)",
                "0 28px 33px rgba(0, 0, 0, 0.6)",
                "0 30px 35px rgba(0, 0, 0, 0.6)",
                "0 32px 37px rgba(0, 0, 0, 0.6)",
                "0 34px 39px rgba(0, 0, 0, 0.6)",
                "0 36px 41px rgba(0, 0, 0, 0.6)",
                "0 38px 43px rgba(0, 0, 0, 0.6)",
                "0 40px 45px rgba(0, 0, 0, 0.6)",
                "0 42px 47px rgba(0, 0, 0, 0.6)",
                "0 44px 49px rgba(0, 0, 0, 0.6)",
                "0 46px 51px rgba(0, 0, 0, 0.6)",
                "0 10px 15px rgba(0, 0, 0, 0.6)"
            ]
        }
    };
}
