using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Yqsbb //仪器设备表
    {
        public string sxdm { get; set; }//学校代码

        [Key]
        public string yqbh { get; set; }//仪器编号

        public string flh { get; set; }//分类号
        public string yqmc { get; set; }//仪器名称
        public string xh { get; set; }//型号
        public string gg { get; set; }//规格
        public string yqly { get; set; }//仪器来源
        public string gbm { get; set; }//国别码
        public Int64 dj { get; set; }//单价
        public string gzrq { get; set; }//购置日期
        public string xzm { get; set; }//现状码
        public string xyfx { get; set; }//使用方向
        public string dwbh { get; set; }//单位编号
        public string dwmc { get; set; }//单位名称
    }

}