namespace MVCSkeleton.Presentation.Constants
{
    public static class ProductListConstants
    {
        public const string FindDeleteButtonInGridXPath = "//td/a[contains(@class, 'k-grid-delete')]";
        public const string FindProductsGridXPath = "//div[@id ='"+ ProductConstants.ProductsGrid +"']";
        public const string FindRowsInProductsGridXPath = FindProductsGridXPath + "//tr[@role ='row']";
    }
}