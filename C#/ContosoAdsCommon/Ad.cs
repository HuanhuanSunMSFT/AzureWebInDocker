using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ContosoAdsCommon
{
    public enum Category
    {
        Cars,
        [Display(Name="Real Estate")]
        RealEstate,
        [Display(Name = "Free Stuff")]
        FreeStuff
    }
    public class Ad : TableEntity
    {
        public Ad()
        {

        }

        public Ad ToAd()
        {
            this.PartitionKey = this.Category;
            this.RowKey = this.Id;
            return this;
        }

        public string Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int Price { get; set; }
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [StringLength(2083)]
        [DisplayName("Full-size Image")]
        public string ImageURL { get; set; }
        
        [StringLength(2083)]
        [DisplayName("Thumbnail")]
        public string ThumbnailURL { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostedDate { get; set; }
        public string Category
        {
            get
            {
                return CategoryEnum.Value.ToString();
            }
            set
            {
                CategoryEnum = (Category)Enum.Parse(typeof(Category), value);
            }
        }
        [IgnoreProperty]
        public Category? CategoryEnum { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
    }

}

