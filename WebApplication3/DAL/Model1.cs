namespace WebApplication3.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer<Model1>(new DBInitializer());
        }

        public virtual DbSet<MyEntitySet> MyEntitySet { get; set; }
        public IEnumerable<MyEntitySet> GetMyEntitySet()
        {
            return this.MyEntitySet.ToList<MyEntitySet>();
        }
        public void InsertEntity(MyEntitySet department)
        {
            try
            {
                department.Id = GenerateEntityID();
                this.MyEntitySet.Add(department);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }
        public void DeleteEntity(MyEntitySet department)
        {
            try
            {
                this.MyEntitySet.Attach(department);
                this.MyEntitySet.Remove(department);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }
        public void UpdateEntity(MyEntitySet entity)
        {
            try
            {
                var item=this.MyEntitySet.Where(s=>s.Id== entity.Id).First<MyEntitySet>();
                item.Name=entity.Name;
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }
        private Int32 GenerateEntityID()
        {
            Int32 maxDepartmentID = 0;
            var department = (from d in GetMyEntitySet()
                              orderby d.Id descending
                              select d).FirstOrDefault();
            if (department != null)
            {
                maxDepartmentID = department.Id + 1;
            }
            return maxDepartmentID;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
