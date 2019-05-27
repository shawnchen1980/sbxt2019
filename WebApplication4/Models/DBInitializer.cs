using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<Sb> defaultStandards = new List<Sb>();

            defaultStandards.Add(new Sb() { SbId=1 });
            defaultStandards.Add(new Sb() { SbId = 2 });
            defaultStandards.Add(new Sb() { SbId = 3 });

            context.Sbs.AddRange(defaultStandards);

            IList<Yqsbb> defaultYqsbbs = new List<Yqsbb>();
            defaultYqsbbs.Add(new Yqsbb() { yqbh = "abc123", yqmc = "笔记本电脑", dj = 5000, dwbh = "123", dwmc = "信息学院" });
            defaultYqsbbs.Add(new Yqsbb() { yqbh = "abc124", yqmc = "台式电脑", dj = 3000, dwbh = "123", dwmc = "信息学院" });
            defaultYqsbbs.Add(new Yqsbb() { yqbh = "abc125", yqmc = "服务器", dj = 13000, dwbh = "123", dwmc = "信息学院" });

            context.Yqsbbs.AddRange(defaultYqsbbs);
            base.Seed(context);
        }
    }
}