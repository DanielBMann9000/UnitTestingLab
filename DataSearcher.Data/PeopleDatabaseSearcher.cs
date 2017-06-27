﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;
using DataSearcher.Model;

namespace DataSearcher.Data
{
    public class PeopleDatabaseSearcher
    {
        static PeopleDatabaseSearcher()
        {
            var firstNames = new[] { "Mary", "Patricia", "Jennifer", "Elizabeth", "Linda", "Barbara", "Susan", "Margaret", "Jessica", "Dorothy", "Sarah", "Karen", "Nancy", "Betty", "Lisa", "Sandra", "Helen", "Ashley", "Donna", "Kimberly", "Carol", "Michelle", "Emily", "Amanda", "Melissa", "Deborah", "Laura", "Stephanie", "Rebecca", "Sharon", "Cynthia", "Kathleen", "Ruth", "Anna", "Shirley", "Amy", "Angela", "Virginia", "Brenda", "Pamela", "Catherine", "Katherine", "Nicole", "Christine", "Janet", "Debra", "Samantha", "Carolyn", "Rachel", "Heather", "Maria", "Diane", "Frances", "Joyce", "Julie", "Emma", "Evelyn", "Martha", "Joan", "Kelly", "Christina", "Lauren", "Judith", "Alice", "Victoria", "Doris", "Ann", "Jean", "Cheryl", "Marie", "Megan", "Kathryn", "Andrea", "Jacqueline", "Gloria", "Teresa", "Janice", "Sara", "Rose", "Hannah", "Julia", "Theresa", "Judy", "Grace", "Beverly", "Denise", "Marilyn", "Mildred", "Amber", "Danielle", "Brittany", "Olivia", "Diana", "Jane", "Lori", "Madison", "Tiffany", "Kathy", "Tammy", "Crystal", "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles", "Thomas", "Christopher", "Daniel", "Matthew", "Donald", "Anthony", "Paul", "Mark", "George", "Steven", "Kenneth", "Andrew", "Edward", "Joshua", "Brian", "Kevin", "Ronald", "Timothy", "Jason", "Jeffrey", "Gary", "Ryan", "Nicholas", "Eric", "Jacob", "Stephen", "Jonathan", "Larry", "Frank", "Scott", "Justin", "Brandon", "Raymond", "Gregory", "Samuel", "Benjamin", "Patrick", "Jack", "Dennis", "Jerry", "Alexander", "Tyler", "Henry", "Douglas", "Peter", "Aaron", "Walter", "Jose", "Adam", "Zachary", "Harold", "Nathan", "Kyle", "Carl", "Arthur", "Gerald", "Roger", "Lawrence", "Keith", "Albert", "Jeremy", "Terry", "Joe", "Sean", "Willie", "Jesse", "Austin", "Christian", "Ralph", "Billy", "Bruce", "Bryan", "Roy", "Eugene", "Ethan", "Louis", "Wayne", "Jordan", "Harry", "Russell", "Alan", "Juan", "Philip", "Randy", "Dylan", "Howard", "Vincent", "Bobby", "Johnny", "Phillip", "Shawn" };
            var lastNames = new[] { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR", "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "GARCIA", "MARTINEZ", "ROBINSON", "CLARK", "RODRIGUEZ", "LEWIS", "LEE", "WALKER", "HALL", "ALLEN", "YOUNG", "HERNANDEZ", "KING", "WRIGHT", "LOPEZ", "HILL", "SCOTT", "GREEN", "ADAMS", "BAKER", "GONZALEZ", "NELSON", "CARTER", "MITCHELL", "PEREZ", "ROBERTS", "TURNER", "PHILLIPS", "CAMPBELL", "PARKER", "EVANS", "EDWARDS", "COLLINS", "STEWART", "SANCHEZ", "MORRIS", "ROGERS", "REED", "COOK", "MORGAN", "BELL", "MURPHY", "BAILEY", "RIVERA", "COOPER", "RICHARDSON", "COX", "HOWARD", "WARD", "TORRES", "PETERSON", "GRAY", "RAMIREZ", "JAMES", "WATSON", "BROOKS", "KELLY", "SANDERS", "PRICE", "BENNETT", "WOOD", "BARNES", "ROSS", "HENDERSON", "COLEMAN", "JENKINS", "PERRY", "POWELL", "LONG", "PATTERSON", "HUGHES", "FLORES", "WASHINGTON", "BUTLER", "SIMMONS", "FOSTER", "GONZALES", "BRYANT", "ALEXANDER", "RUSSELL", "GRIFFIN", "DIAZ", "HAYES", "MYERS", "FORD", "HAMILTON", "GRAHAM", "SULLIVAN", "WALLACE", "WOODS", "COLE", "WEST", "JORDAN", "OWENS", "REYNOLDS", "FISHER", "ELLIS", "HARRISON", "GIBSON", "MCDONALD", "CRUZ", "MARSHALL", "ORTIZ", "GOMEZ", "MURRAY", "FREEMAN", "WELLS", "WEBB", "SIMPSON", "STEVENS", "TUCKER", "PORTER", "HUNTER", "HICKS", "CRAWFORD", "HENRY", "BOYD", "MASON", "MORALES", "KENNEDY", "WARREN", "DIXON", "RAMOS", "REYES", "BURNS", "GORDON", "SHAW", "HOLMES", "RICE", "ROBERTSON", "HUNT", "BLACK", "DANIELS", "PALMER", "MILLS", "NICHOLS", "GRANT", "KNIGHT", "FERGUSON", "ROSE", "STONE", "HAWKINS", "DUNN", "PERKINS", "HUDSON", "SPENCER", "GARDNER", "STEPHENS", "PAYNE", "PIERCE", "BERRY", "MATTHEWS", "ARNOLD", "WAGNER", "WILLIS", "RAY", "WATKINS", "OLSON", "CARROLL", "DUNCAN", "SNYDER", "HART", "CUNNINGHAM", "BRADLEY", "LANE", "ANDREWS", "RUIZ", "HARPER", "FOX", "RILEY", "ARMSTRONG", "CARPENTER", "WEAVER", "GREENE", "LAWRENCE", "ELLIOTT", "CHAVEZ", "SIMS", "AUSTIN", "PETERS", "KELLEY", "FRANKLIN", "LAWSON", "FIELDS", "GUTIERREZ", "RYAN", "SCHMIDT", "CARR", "VASQUEZ", "CASTILLO", "WHEELER", "CHAPMAN", "OLIVER", "MONTGOMERY", "RICHARDS", "WILLIAMSON", "JOHNSTON", "BANKS", "MEYER", "BISHOP", "MCCOY", "HOWELL", "ALVAREZ", "MORRISON", "HANSEN", "FERNANDEZ", "GARZA", "HARVEY", "LITTLE", "BURTON", "STANLEY", "NGUYEN", "GEORGE", "JACOBS", "REID", "KIM", "FULLER", "LYNCH", "DEAN", "GILBERT", "GARRETT", "ROMERO", "WELCH", "LARSON", "FRAZIER", "BURKE", "HANSON", "DAY", "MENDOZA", "MORENO", "BOWMAN", "MEDINA", "FOWLER", "BREWER", "HOFFMAN", "CARLSON", "SILVA", "PEARSON", "HOLLAND", "DOUGLAS", "FLEMING", "JENSEN", "VARGAS", "BYRD", "DAVIDSON", "HOPKINS", "MAY", "TERRY", "HERRERA", "WADE", "SOTO", "WALTERS", "CURTIS", "NEAL", "CALDWELL", "LOWE", "JENNINGS", "BARNETT", "GRAVES", "JIMENEZ", "HORTON", "SHELTON", "BARRETT", "OBRIEN", "CASTRO", "SUTTON", "GREGORY", "MCKINNEY", "LUCAS", "MILES", "CRAIG", "RODRIQUEZ", "CHAMBERS", "HOLT", "LAMBERT", "FLETCHER", "WATTS", "BATES", "HALE", "RHODES", "PENA", "BECK", "NEWMAN", "HAYNES", "MCDANIEL", "MENDEZ", "BUSH", "VAUGHN", "PARKS", "DAWSON", "SANTIAGO", "NORRIS", "HARDY", "LOVE", "STEELE", "CURRY", "POWERS", "SCHULTZ", "BARKER", "GUZMAN", "PAGE", "MUNOZ", "BALL", "KELLER", "CHANDLER", "WEBER", "LEONARD", "WALSH", "LYONS", "RAMSEY", "WOLFE", "SCHNEIDER", "MULLINS", "BENSON", "SHARP", "BOWEN", "DANIEL", "BARBER", "CUMMINGS", "HINES", "BALDWIN", "GRIFFITH", "VALDEZ", "HUBBARD", "SALAZAR", "REEVES", "WARNER", "STEVENSON", "BURGESS", "SANTOS", "TATE", "CROSS", "GARNER", "MANN", "MACK", "MOSS", "THORNTON", "DENNIS", "MCGEE", "FARMER", "DELGADO", "AGUILAR", "VEGA", "GLOVER", "MANNING", "COHEN", "HARMON", "RODGERS", "ROBBINS", "NEWTON", "TODD", "BLAIR", "HIGGINS", "INGRAM", "REESE", "CANNON", "STRICKLAND", "TOWNSEND", "POTTER", "GOODWIN", "WALTON", "ROWE", "HAMPTON", "ORTEGA", "PATTON", "SWANSON", "JOSEPH", "FRANCIS", "GOODMAN", "MALDONADO", "YATES", "BECKER", "ERICKSON", "HODGES", "RIOS", "CONNER", "ADKINS", "WEBSTER", "NORMAN", "MALONE", "HAMMOND", "FLOWERS", "COBB", "MOODY", "QUINN", "BLAKE", "MAXWELL", "POPE", "FLOYD", "OSBORNE", "PAUL", "MCCARTHY", "GUERRERO", "LINDSEY", "ESTRADA", "SANDOVAL", "GIBBS", "TYLER", "GROSS", "FITZGERALD", "STOKES", "DOYLE", "SHERMAN", "SAUNDERS", "WISE", "COLON", "GILL", "ALVARADO", "GREER", "PADILLA", "SIMON", "WATERS", "NUNEZ", "BALLARD", "SCHWARTZ", "MCBRIDE", "HOUSTON", "CHRISTENSEN", "KLEIN", "PRATT", "BRIGGS", "PARSONS", "MCLAUGHLIN", "ZIMMERMAN", "FRENCH", "BUCHANAN", "MORAN", "COPELAND", "ROY", "PITTMAN", "BRADY", "MCCORMICK", "HOLLOWAY", "BROCK", "POOLE", "FRANK", "LOGAN", "OWEN", "BASS", "MARSH", "DRAKE", "WONG", "JEFFERSON", "PARK", "MORTON", "ABBOTT", "SPARKS", "PATRICK", "NORTON", "HUFF", "CLAYTON", "MASSEY", "LLOYD", "FIGUEROA", "CARSON", "BOWERS", "ROBERSON", "BARTON", "TRAN", "LAMB", "HARRINGTON", "CASEY", "BOONE", "CORTEZ", "CLARKE", "MATHIS", "SINGLETON", "WILKINS", "CAIN", "BRYAN", "UNDERWOOD", "HOGAN", "MCKENZIE", "COLLIER", "LUNA", "PHELPS", "MCGUIRE", "ALLISON", "BRIDGES", "WILKERSON", "NASH", "SUMMERS", "ATKINS", "WILCOX", "PITTS", "CONLEY", "MARQUEZ", "BURNETT", "RICHARD", "COCHRAN", "CHASE", "DAVENPORT", "HOOD", "GATES", "CLAY", "AYALA", "SAWYER", "ROMAN", "VAZQUEZ", "DICKERSON", "HODGE", "ACOSTA", "FLYNN", "ESPINOZA", "NICHOLSON", "MONROE", "WOLF", "MORROW", "KIRK", "RANDALL", "ANTHONY", "WHITAKER", "OCONNOR", "SKINNER", "WARE", "MOLINA", "KIRBY", "HUFFMAN", "BRADFORD", "CHARLES", "GILMORE", "DOMINGUEZ", "ONEAL", "BRUCE", "LANG", "COMBS", "KRAMER", "HEATH", "HANCOCK", "GALLAGHER", "GAINES", "SHAFFER", "SHORT", "WIGGINS", "MATHEWS", "MCCLAIN", "FISCHER", "WALL", "SMALL", "MELTON", "HENSLEY", "BOND", "DYER", "CAMERON", "GRIMES", "CONTRERAS", "CHRISTIAN", "WYATT", "BAXTER", "SNOW", "MOSLEY", "SHEPHERD", "LARSEN", "HOOVER", "BEASLEY", "GLENN", "PETERSEN", "WHITEHEAD", "MEYERS", "KEITH", "GARRISON", "VINCENT", "SHIELDS", "HORN", "SAVAGE", "OLSEN", "SCHROEDER", "HARTMAN", "WOODARD", "MUELLER", "KEMP", "DELEON", "BOOTH", "PATEL", "CALHOUN", "WILEY", "EATON", "CLINE", "NAVARRO", "HARRELL", "LESTER", "HUMPHREY", "PARRISH", "DURAN", "HUTCHINSON", "HESS", "DORSEY", "BULLOCK", "ROBLES", "BEARD", "DALTON", "AVILA", "VANCE", "RICH", "BLACKWELL", "YORK", "JOHNS", "BLANKENSHIP", "TREVINO", "SALINAS", "CAMPOS", "PRUITT", "MOSES", "CALLAHAN", "GOLDEN", "MONTOYA", "HARDIN", "GUERRA", "MCDOWELL", "CAREY", "STAFFORD", "GALLEGOS", "HENSON", "WILKINSON", "BOOKER", "MERRITT", "MIRANDA", "ATKINSON", "ORR", "DECKER", "HOBBS", "PRESTON", "TANNER", "KNOX", "PACHECO", "STEPHENSON", "GLASS", "ROJAS", "SERRANO", "MARKS", "HICKMAN", "ENGLISH", "SWEENEY", "STRONG", "PRINCE", "MCCLURE", "CONWAY", "WALTER", "ROTH", "MAYNARD", "FARRELL", "LOWERY", "HURST", "NIXON", "WEISS", "TRUJILLO", "ELLISON", "SLOAN", "JUAREZ", "WINTERS", "MCLEAN", "RANDOLPH", "LEON", "BOYER", "VILLARREAL", "MCCALL", "GENTRY", "CARRILLO", "KENT", "AYERS", "LARA", "SHANNON", "SEXTON", "PACE", "HULL", "LEBLANC", "BROWNING", "VELASQUEZ", "LEACH", "CHANG", "HOUSE", "SELLERS", "HERRING", "NOBLE", "FOLEY", "BARTLETT", "MERCADO", "LANDRY", "DURHAM", "WALLS", "BARR", "MCKEE", "BAUER", "RIVERS", "EVERETT", "BRADSHAW", "PUGH", "VELEZ", "RUSH", "ESTES", "DODSON", "MORSE", "SHEPPARD", "WEEKS", "CAMACHO", "BEAN", "BARRON", "LIVINGSTON", "MIDDLETON", "SPEARS", "BRANCH", "BLEVINS", "CHEN", "KERR", "MCCONNELL", "HATFIELD", "HARDING", "ASHLEY", "SOLIS", "HERMAN", "FROST", "GILES", "BLACKBURN", "WILLIAM", "PENNINGTON", "WOODWARD", "FINLEY", "MCINTOSH", "KOCH", "BEST", "SOLOMON", "MCCULLOUGH", "DUDLEY", "NOLAN", "BLANCHARD", "RIVAS", "BRENNAN", "MEJIA", "KANE", "BENTON", "JOYCE", "BUCKLEY", "HALEY", "VALENTINE", "MADDOX", "RUSSO", "MCKNIGHT", "BUCK", "MOON", "MCMILLAN", "CROSBY", "BERG", "DOTSON", "MAYS", "ROACH", "CHURCH", "CHAN", "RICHMOND", "MEADOWS", "FAULKNER", "ONEILL", "KNAPP", "KLINE", "BARRY", "OCHOA", "JACOBSON", "GAY", "AVERY", "HENDRICKS", "HORNE", "SHEPARD", "HEBERT", "CHERRY", "CARDENAS", "MCINTYRE", "WHITNEY", "WALLER", "HOLMAN", "DONALDSON", "CANTU", "TERRELL", "MORIN", "GILLESPIE", "FUENTES", "TILLMAN", "SANFORD", "BENTLEY", "PECK", "KEY", "SALAS", "ROLLINS", "GAMBLE", "DICKSON", "BATTLE", "SANTANA", "CABRERA", "CERVANTES", "HOWE", "HINTON", "HURLEY", "SPENCE", "ZAMORA", "YANG", "MCNEIL", "SUAREZ", "CASE", "PETTY", "GOULD", "MCFARLAND", "SAMPSON", "CARVER", "BRAY", "ROSARIO", "MACDONALD", "STOUT", "HESTER", "MELENDEZ", "DILLON", "FARLEY", "HOPPER", "GALLOWAY", "POTTS", "BERNARD", "JOYNER", "STEIN", "AGUIRRE", "OSBORN", "MERCER", "BENDER", "FRANCO", "ROWLAND", "SYKES", "BENJAMIN", "TRAVIS", "PICKETT", "CRANE", "SEARS", "MAYO", "DUNLAP", "HAYDEN", "WILDER", "MCKAY", "COFFEY", "MCCARTY", "EWING", "COOLEY", "VAUGHAN", "BONNER", "COTTON", "HOLDER", "STARK", "FERRELL", "CANTRELL", "FULTON", "LYNN", "LOTT", "CALDERON", "ROSA", "POLLARD", "HOOPER", "BURCH", "MULLEN", "FRY", "RIDDLE", "LEVY", "DAVID", "DUKE", "ODONNELL", "GUY", "MICHAEL", "BRITT", "FREDERICK", "DAUGHERTY", "BERGER", "DILLARD", "ALSTON", "JARVIS", "FRYE", "RIGGS", "CHANEY", "ODOM", "DUFFY", "FITZPATRICK", "VALENZUELA", "MERRILL", "MAYER", "ALFORD", "MCPHERSON", "ACEVEDO", "DONOVAN", "BARRERA", "ALBERT", "COTE", "REILLY", "COMPTON", "RAYMOND", "MOONEY", "MCGOWAN", "CRAFT", "CLEVELAND", "CLEMONS", "WYNN", "NIELSEN", "BAIRD", "STANTON", "SNIDER", "ROSALES", "BRIGHT", "WITT", "STUART", "HAYS", "HOLDEN", "RUTLEDGE", "KINNEY", "CLEMENTS", "CASTANEDA", "SLATER", "HAHN", "EMERSON", "CONRAD", "BURKS", "DELANEY", "PATE", "LANCASTER", "SWEET", "JUSTICE", "TYSON", "SHARPE", "WHITFIELD", "TALLEY", "MACIAS", "IRWIN", "BURRIS", "RATLIFF", "MCCRAY", "MADDEN", "KAUFMAN", "BEACH", "GOFF", "CASH", "BOLTON", "MCFADDEN", "LEVINE", "GOOD", "BYERS", "KIRKLAND", "KIDD", "WORKMAN", "CARNEY", "DALE", "MCLEOD", "HOLCOMB", "ENGLAND", "FINCH", "HEAD", "BURT", "HENDRIX", "SOSA", "HANEY", "FRANKS", "SARGENT", "NIEVES", "DOWNS", "RASMUSSEN", "BIRD", "HEWITT", "LINDSAY", "LE", "FOREMAN", "VALENCIA", "ONEIL", "DELACRUZ", "VINSON", "DEJESUS", "HYDE", "FORBES", "GILLIAM", "GUTHRIE", "WOOTEN", "HUBER", "BARLOW", "BOYLE", "MCMAHON", "BUCKNER", "ROCHA", "PUCKETT", "LANGLEY", "KNOWLES", "COOKE", "VELAZQUEZ", "WHITLEY", "NOEL", "VANG" };

            var rng = new Random();

            var numberOfRecords = rng.Next(5, 50);
            //randomize the database   
            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            using (var cmd = new SqlCeCommand("DELETE FROM People", con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }

            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            {
                con.Open();
                for (int i = 0; i < numberOfRecords; i++)
                {
                    using (var cmd = new SqlCeCommand("INSERT INTO People (FirstName, LastName, LastLogin) VALUES (@FirstName, @LastName, @LastLogin)", con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstNames[rng.Next(0,firstNames.Length - 1)]);
                        cmd.Parameters.AddWithValue("@LastName", lastNames[rng.Next(0, lastNames.Length - 1)]);
                        cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now.AddDays(-rng.Next(0, 365)));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = new List<Person>();
            using (var con = new SqlCeConnection("Data Source=PeopleDatabase.sdf;Persist Security Info=False;"))
            using (var cmd = new SqlCeCommand("SELECT * FROM People", con))
            {
                con.Open();
                var results = cmd.ExecuteReader();
                people.AddRange(results.Cast<DbDataRecord>().Select(result => new Person
                {
                    FirstName = result["FirstName"].ToString(),
                    LastName = result["LastName"].ToString(),
                    LastLogin = DateTime.Parse(result["LastLogin"].ToString())
                }));
            }
            
            return people;
        }
    }
}
