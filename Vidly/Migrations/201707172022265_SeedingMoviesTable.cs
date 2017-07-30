namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMoviesTable : DbMigration
    {
        public override void Up()
        {
      Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES('Hangover', 2, '17 Jan 1997', '9 Nov 2015', 5)");
      Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES('Die Hard', 1, '23 Sep 2006', '12 May 2014', 2)");
      Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES('The Terminator', 1, '17 Jan 1997', '11 Apr 2012', 10)");
      Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES('Toy Story', 4, '16 Aug 1995', '17 Sep 2010', 3)");
      Sql("INSERT INTO Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES('Titanic', 3, '12 Oct 1997', '8 Jan 2013', 2)");
    }
        
        public override void Down()
        {
        }
    }
}
