namespace TZMDotNetCore.PizzaApi.Features.Quaries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = 
            @"select po.*,p.Pizza, p.Price from Tbl_PizzaOrder po
             inner join Tbl_Pizza p on p.PizzaId = po.PizzaId
             where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
        public static string PizzaOrderDetailQuery { get; } = 
            @"select pod.*,pe.PizzaExtraName,pe.Price from Tbl_PizzaOrderDetail pod
             inner join [dbo].[Tbl_PizzaExtra] pe on pod.PizzaExtraId = pe.PizzaExtraId
             where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}
