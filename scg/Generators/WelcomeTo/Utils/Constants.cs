namespace scg.Generators.WelcomeTo;

public static class Constants
{
    public static int NUM_TURNS = 27;
    public static string FIGURE_UNICODES = "[size=20]🌴🔶🌊📮🏦♐[/size]";

    public static string GREEN_FIGURE = "\uD83C\uDF34";
    public static string BLUE_FIGURE = "\uD83C\uDF0A";
    public static string GRAY_FIGURE = "\uD83C\uDFE6";
    public static string ORANGE_FIGURE = "\uD83D\uDD36";
    public static string RED_FIGURE = "\uD83D\uDCEE";
    public static string PURPLE_FIGURE = "♐";

    public static string CITY_PLAN_BLOCK = "\uD83D\uDD32";

    public static string BLOCK_PREFIX = "[o][c]\n";
    public static string BLOCK_SUFFIX = "[/c][/o]";

    public static string CITY_PLAN_NAME = "[b][size=15]City Plan #{0}[/size][/b]\n";
    public static string CITY_PLAN_HIGHER = "[size=15]Higher Points: [b]{0}[/b][/size]\n";
    public static string CITY_PLAN_SIZE_PREFIX = "[b][size=15]";
    public static string CITY_PLAN_SIZE_SUFFIX = "[/size][/b]\n";
    public static string CITY_PLAN_LOWER = "[size=15]Lower Points: [b]{0}[/b][/size]\n";
    public static string CITY_SPACE_BETWEEN = "[size=15][microbadge=3][/size][b][size=15][color=#a5a351][/color][/size][/b]\n" +
                                              "__________________________________________________________________________________________________________________________\n" +
                                              "[b][size=15][/size][/b]\n";

    public static string GetFigureForEnum(Figure fig) {
        switch (fig) {
            case Figure.GREEN:
                return GREEN_FIGURE;
            case Figure.BLUE:
                return BLUE_FIGURE;
            case Figure.GRAY:
                return GRAY_FIGURE;
            case Figure.ORANGE:
                return ORANGE_FIGURE;
            case Figure.RED:
                return RED_FIGURE;
            case Figure.PURPLE:
                return PURPLE_FIGURE;
            default:
                return GREEN_FIGURE;
        }
    }
    public static string SOLO_CARD = "[o][c]\n" +
                                     "[b][size=15]\uD83C\uDCCF[/size][/b]\n" +
                                     "[b][size=15]Solo Card![/size][/b]\n" +
                                     "[size=12]Turn over the Plan cards that are not yet \"approved\" to their \"approved\" side.[/size]\n" +
                                     "[size=15][microbadge=3][/size][b][size=15][color=#a5a351][/color][/size][/b]\n" +
                                     "__________________________________________________________________________________________________________________________\n" +
                                     "[b][size=15][/size][/b]\n" +
                                     "[/c][/o]";

    public static string THREE_CARDS = "[o][c]\n" +
                                       "[b][size=15]{0} [{1}][/size][/b]\n" +
                                       "[b][size=15]{2} [{3}][/size][/b]\n" +
                                       "[b][size=15]{4} [{5}][/size][/b]\n" +
                                       "[size=15][microbadge=3][/size][b][size=15][color=#a5a351][/color][/size][/b]\n" +
                                       "__________________________________________________________________________________________________________________________\n" +
                                       "[b][size=15][/size][/b]\n" +
                                       "[/c][/o]";
}