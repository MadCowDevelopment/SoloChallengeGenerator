namespace scg
{
    public static class GlobalIdentifiers
    {
        /// <summary>
        /// This is the ID of the yearly Solo Challenges geeklist. Needs to be updated once a year.
        /// </summary>
#if DEBUG
        public static readonly int ListId = 249689; // For testing purposes.
#else
        public static readonly int ListId = 266253; // Solo challenges 2020.
#endif
    }
}
