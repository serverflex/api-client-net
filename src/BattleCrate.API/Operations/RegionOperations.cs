namespace BattleCrate.API.Operations
{
    public class RegionOperations : BaseOperations//, IRegionOperations
    {
        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Regions.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public RegionOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
