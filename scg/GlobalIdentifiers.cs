namespace scg
{
    public static class GlobalIdentifiers
    {
        /// <summary>
        /// This is the ID of the yearly Solo Challenges geeklist. Needs to be updated once a year.
        /// </summary>
#if DEBUG
        public static readonly int ListId = 291214; // For testing purposes.
#else
        public static readonly int ListId = 280790; // Solo challenges 2021.
#endif
    }
}