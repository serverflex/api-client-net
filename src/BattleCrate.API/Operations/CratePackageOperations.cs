namespace BattleCrate.API.Operations
{
    public class CratePackageOperations : BaseOperations//, ICratePackageOperations
    {
        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crate Packages.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CratePackageOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
