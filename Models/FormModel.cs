namespace FormProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FormModel : DbContext
    {
        public FormModel()
            : base("name=FormModel")
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
    }
}
