namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketWithProductAndTable
    {
        public int BasketID { get; set; }
        public int MenuTableID { get; set; }
        public string MenuTableName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
