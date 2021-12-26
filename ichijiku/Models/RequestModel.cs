using System;
using System.Collections.Generic;

namespace ichijiku.Models
{
    public class RequestModel
    {
        public int Control_id { get; set; }
        public string Control_number { get; set; }
        public string Contents { get; set; }
        public string Memo { get; set; }
        public List<ItemModel> ItemModels { get; set; }
    }

    public class ItemModel
    {
        public int Item_id { get; set; }
        public int Billing_id { get; set; }
        public int Charge_id { get; set; }
        public string Zuban { get; set; }
        public string Hinban { get; set; }
        public int Negotiated_price { get; set; }
        public List<JobModel> JobModels { get; set; }
        public List<WorkModel> WorkModels { get; set; }
    }

    public class JobModel
    {
        public int Job_id { get; set; }
        public int Task_id { get; set; }
        public int Quantity { get; set; }
        public List<OptionModel> OptionModels { get; set; }
    }

    public class OptionModel
    {
        public int Task_option_id { get; set; }
        public int Option_id { get; set; }
        public int Quantity { get; set; }
    }

    public class WorkModel
    {
        public int Work_id { get; set; }
        public string Worker_id { get; set; }
        public int Rate { get; set; }
        public bool Hide { get; set; }
        public int Equipment { get; set; }
        public List<WorkTimeModel> WorkTimeModels { get; set; }
    }
    public class WorkTimeModel
    {
        public int Work_time_id { get; set; }
        public DateTime Work_day { get; set; }
        public float Work_time { get; set; }
    }
}
