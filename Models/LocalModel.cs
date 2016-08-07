namespace FormProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public class LocalModel : DbContext
    {
        // Your context has been configured to use a 'LocalModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FormProject.Models.LocalModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LocalModel' 
        // connection string in the application configuration file.
        public LocalModel()
            : base("name=LocalModel")
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<PossibleAnswer> PossibleAnswer { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Session> Session { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<PossibleAnswer>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}