namespace JsonCrafterOld
{
    public static class JsonCrafterConstants
    {
        public static class Hal
        {
            public const string MediaTypeHeaderValue = "application/hal+json";
            public const string FormatName = "hal+json";

            public static class Formatting
            {
                public const string LinkToSelf = "self";
                public const string LinkToPrevious = "prev";
                public const string LinkToNext = "next";
                public const string LinkToFirst = "first";
                public const string LinkToLast = "last";

                public const char CuriesDelimiter = ':';
                public const string CuriesObject = "_curies";
                public const string LinkObject = "_links";
                public const string EmbeddedObject = "_embedded";
            }
        }

        public static class JsonApi
        {
            public const string MediaTypeHeaderValue = "application/vnd.api+json";
            public const string FormatName = "vnd.api+json";
        }

        public static class Misc
        {
            public const string DefaultParameterName = "param";
        }

        public static class AppendixFormatting
        {
            public const char SpecialPropertyPrefix = '#';
        }
    }
}
