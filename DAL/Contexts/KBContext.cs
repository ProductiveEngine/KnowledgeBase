using DAL.Base;
using DAL.Models;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class KBContext : BaseContext<KBContext>
    {
        public DbSet<CategoryVO> Categories {get; set;}
        public DbSet<CommentVO> Comments {get; set;}
        public DbSet<ProblemVO> Problems {get; set;}
        public DbSet<SolutionVO> Solutions {get; set;}
        public DbSet<StepVO> Steps {get; set;}
        public DbSet<SubCategoryVO> SubCategories {get; set;}
        public DbSet<UsefulInfoVO> UsefulInfos { get; set;}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new LineItemMap());
        //}
    }
}
