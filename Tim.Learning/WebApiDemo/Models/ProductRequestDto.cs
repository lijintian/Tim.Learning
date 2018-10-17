using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class ProductRequestDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required(ErrorMessage ="必填字段")]
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Max​Length​(20)]
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DisplayFormat]
        public string Category { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
    }
}