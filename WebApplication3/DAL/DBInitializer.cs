using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.DAL
{
    public class DBInitializer: CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            IList<MyEntitySet> defaultStandards = new List<MyEntitySet>();

            defaultStandards.Add(new MyEntitySet() { Id = 1, Name = "First Standard" });
            defaultStandards.Add(new MyEntitySet() { Id = 2, Name = "Second Standard" });
            defaultStandards.Add(new MyEntitySet() { Id = 3, Name = "Third Standard" });

            context.MyEntitySet.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}