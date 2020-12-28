using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hotel_Rooms_Management.Utils
{
    class FileService
    {
        public void WriteReportData(string path, FullReportData data, string title)
        {
            var csv = new StringBuilder();
            csv.AppendLine(title);
            csv.AppendLine("Номер заказа;Дата заказа;Номер комнаты;Дополнительные услуги;Стоимость заказа;Имя посетителя");
            foreach (ReportOrderData item in data.OrderData)
                csv.AppendLine($"{item.Id};{item.DateShort};{item.Room};{item.serviceComposition};{item.Cost};{item.CustomerName}");
            csv.AppendLine("Дополнительная информация");
            csv.AppendLine($"Количество заказов;{data.OrderCount}");
            csv.AppendLine($"Минимальная стоимость заказа;{data.MinCost}");
            csv.AppendLine($"Максимальная стоимость заказа;{data.MaxCost}");
            csv.AppendLine($"Общая стоимость;{data.SumCost}");

            File.WriteAllText(path, csv.ToString(), Encoding.UTF8);
        }

        public class ReportOrderData
        {
            public int Id { get; set; }
            public string DateShort { get; set; }

            public int Room { get; set; }

            public string serviceComposition { get; set; }

            public int Cost { get; set; }

            public string CustomerName { get; set; }
        }

        public class FullReportData
        {
            public List<ReportOrderData> OrderData { get; set; }

            public int OrderCount { get; set; }

            public int MaxCost { get; set; }

            public int MinCost { get; set; }

            public int SumCost { get; set; }
        }
    }
}