namespace AzureAlgos.Models.Output
{
    /// <summary>
    /// Generic result with data and metrics.
    /// </summary>
    public class GenericResult
    {
        public dynamic Data { get; set; }

        public string SpaceComplexity { get; set; }

        public string TimeComplexity { get; set; }
    }
}
