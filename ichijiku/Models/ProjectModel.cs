using System;
using System.Collections.Generic;
namespace ichijiku.Models
{
    public class ProjectModel
    {
        public int? Project_Id { get; set; }
        public string Project_Title { get; set; } = "";
        public string Project_Description { get; set; } = "";
        public string Project_Cd { get; set; } = "";
        public int Project_state_Id { get; set; } = 0;
        public string? Project_State { get; set; }
        public int Customer_Id { get; set; } = 0;
        public string? Customer_Name { get; set; }
        public string? Model_Cd { get; set; } = "";
        public bool Hide { get; set; } = false;
        public List<ProductModel>? ProductModels { get; set; }
    }

    public class ProductModel
    {
        public int? Product_Id { get;set; }
        public string Product_Cd { get; set; } = "";
        public int Product_State_Id { get; set; } = 0;
        public string Product_Name { get; set; } = "";
        public string Customer_Number { get; set; } = "";
        public string Customer_Part_Name { get; set; } = "";
        public int? Image_File_Id { get; set; }
    }

}
