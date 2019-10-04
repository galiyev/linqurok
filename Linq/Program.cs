using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        #region данные для HR
             static string personSource = @"Макаров Вольдемар, Анисимов Клемент, Суворов Петр, Самойлов Валентин, Зайцев Вадим, Нестеров Алексей, Коновалов Зиновий,
                Громов Алан, Туров Давид, Тимофеев Елисей, Красильников Адриан, Кузьмин Зиновий, Соловьёв Харитон, Зуев Аполлон, Харитонов Влас,
                Буров Илларион, Рыбаков Игнат, Николаев Азарий, Журавлёв Мечеслав, Соколов Витольд, Архипов Аркадий, Сергеев Мирослав, Орлов Сергей,
                Ермаков Руслан, Зыков Евгений, Ефремов Филипп, Котов Вольдемар, Медведев Митрофан,  Андреев Ефрем, Никонов Ян, Селезнёв Андрей,
                Прохоров Юстин, Русаков Любовь, Мельников Максим, Григорьев Лукьян, Веселов Кондрат, Муравьёв Георгий, Гущин Владимир, Муравьёв Владлен,
                Козлов Родион, Шубин Арнольд, Комиссаров Руслан,  Николаев Леонид,  Лаврентьев Эльдар, Терентьев Флор, Андреев Глеб, Филиппов Степан, Ефремов Варлаам,
                Шаров Кирилл";

            static string languagesSource = "СSharp, JavaScript, Java, Swift";
        #endregion
       
        static void Main(string[] args)
        {
            Linq0();
        }


        static void Linq0()
        {
            string[] countries =
            {
                "Afghanistan", "Albania", "Algeria", "American Samoa",
                "Andorra", "Angola", "Anguilla", "Antarctica","Antarctica",
                "Antigua And Barbuda", "Argentina", "Armenia", "Aruba", "Barbados",
                "Belarus", "Belgium", "Belize","Belize", "Benin", "Bermuda", "Bhutan", "Boliviav",
                "Canada","Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad",
                "Chile", "China", "Christmas Island", "Costa Rica", "Cote D'ivoire",
                "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti",
                "Estonia", "China","Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji",
                "Finland", "Finland","France","France", "French Guiana", "French Polynesia", "French Southern Territories",
                "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Guinea", "Guinea-bissau",
                "Guyana", "Haiti", "Heard Island And Mcdonald Islands", "Holy See (Vatican City State)",
                "Honduras", "Hong Kong","Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran",
                "Iraq", "Ireland", "Israel", "Japan","Japan", "Jordan", "Kazakstan", "Kenya", "Kiribati",
                "Kosovo", "Kuwait","Kuwait", "Kyrgyzstan", "Liberia", "Libyan Arab Jamahiriya",
                "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia",
                "Madagascar", "Malawi", "Malawi", "Malaysia", "Maldives","Maldives", "Mali", "Malta", "Marshall Islands",
                "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Federated States Of Micronesia",
                "Republic Of Moldova", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles","Netherlands Antilles", "New Caledonia",
                "New Zealand","Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway",
                "Oman", "Pakistan", "Palau", "Palestinian Territory", "Panama", "Papua New Guinea","Papua New Guinea",
                "Paraguay","Peru","Philippines","Pitcairn","Poland","Portugal","Puerto Rico","Qatar","Romania",
                "Russian Federation","Spain","Sri Lanka","Sudan","Suriname","Svalbard And Jan Mayen","Swaziland","Swaziland",
                "Tunisia","Turkey","Turkey","Turkmenistan","Turks And Caicos Islands","Tuvalu","Uganda","Ukraine","Ukraine",
                "United Arab Emirates","United Kingdom","United States of America","Vietnam","British Virgin Islands","US Virgin Islands",
                "Wallis And Futuna","Western Sahara"};

                        
                var result = from c in countries // в строке «from c in countries» после спецификатора «in» указывается источник данных.
                    where c.Length>10 orderby c.Length
                     select c;

                #region Лямбда выражение
                    Func<string, bool> isLongerThan10 = s =>s.Length>10 ;
                    var result2 = countries.Where((s, index) => index > 10 && s.Length > 15);
                #endregion

                var res1 = from c in countries
                    where c.StartsWith("A")
                    orderby c.Length 
                    select c;

                var sorted = from c in countries
                    let s = from s in countries
                                where s.Contains("a")
                            select s
                    where c.Length > 10 && !s.Contains(c)
                    orderby c.Length descending
                    select c;

               // res1 = countries.Where(name => name.Contains("an")).OrderBy(a => a.Length).Distinct();

                foreach (var country in res1)
                {
                    Console.WriteLine(country);
                }

            #region Анонимный тип в результате

            //var sorted2 = from c in countries
            //        where c.Length > 10  && !c.Contains("a") 
            //        orderby c.Length descending
            //        select new
            //        {
            //            name = c,
            //            len = c.Length
            //        };

            //    sorted2 = countries.Where(c => c.Length > 10 && !c.Contains("a")).OrderByDescending(a => a.Length)
            //        .Select(d => new
            //        {
            //            name = d,
            //            len = d.Length
            //        });

            //    foreach (var country in sorted2)
            //    {
            //        Console.WriteLine("Name {0} Len {1}",country.name, country.len);
            //    }

                #endregion


                #region Агрегаты
                var maxLen = (from c in countries
                            orderby c.Length descending
                            select c.Length).FirstOrDefault();

                        var maxLen2 = (from c in countries
                            orderby c.Length descending
                            select c.Length).Max();


                        var average = (from c in countries
                            orderby c.Length descending
                            select c.Length).Average();
                
                       // Console.WriteLine("Maxlen is {0} {1}  Average {2}",maxLen, maxLen2, Math.Round(average));
                    #endregion


          

                
                

                Console.WriteLine(result2.Count());

                Console.ReadLine();
         }

        /// <summary>
        /// HR отдел софтверной компании
        /// </summary>
        private static void Linq1()
        {
            var personsString = personSource.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);

            var devLangs = languagesSource.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            string[] deps = {"Games", "System", "Enterpise"};

            Random random = new Random();

            List<Person> persons = new List<Person>();

            foreach (var pstr in personsString)
            {
                var langNo = (new Random()).Next(1,4);
                Person person = new Person()
                {
                    Skills = Shuffle(devLangs, langNo).ToList(),
                    Dep = Shuffle(deps,1).FirstOrDefault(),
                    Age = random.Next(20, 40),
                    Name = pstr
                };
                Console.WriteLine("ФИ: {0}  Возраст: {1} Департамент: {2} Скилзы: {3} ", person.Name, person.Age, person.Dep, string.Join(", ", person.Skills));
                persons.Add(person);
            }

            // выборка количество программистов на том или ином языке
            var result = from d in devLangs
                let countOfLang = (from p in persons where p.Skills.Contains(d) select p).Count()

                select new
                {
                    langName = d,
                    countLang = countOfLang
                };

                Console.ReadLine();

                foreach(var languageInfo in result){
                    Console.WriteLine("{0} {1}", languageInfo.langName, languageInfo.countLang);
                }
            Console.ReadLine();
        }
        

        static void Linq2()
        {
            string[] teams = { "Бавария", "Спартак", "Реал Мадрид" };
            var teamsStarted = (from t in teams
                where t.Contains('р')
                orderby t.Length
                select t).ToList();

            teams[1] = "Барыс";

            //teamsStarted.Remove("Спартак");

            var result = teams.Where(a => a.Contains('р')).OrderBy(a => a.Length).Select(c => c);

            Console.WriteLine(teamsStarted.GetType());

            foreach (var t in result)
            {
                Console.WriteLine(t);

            }

            Console.ReadLine();
        }


        static void Linq3()
        {

            string[] devLang = {"C#","Prolog", "Dephi", "VB", "JavaScript"};

            string[] soft = {"Adobe XD", "Axure", "Corel" };
            
            List<Person> persons = new List<Person>()
            {
                new Person()
                {
                    Id=1, Age = 24, Dep = "DEV", Name = "Иванова Наталья",
                    Skills = new List<string>(){"С#","Prolog"}
                },
                new Person()
                {
                    Id=2, Age = 22, Dep = "DEV", Name = "Сидоров Алексей",
                    Skills = new List<string>(){"С#","Pascal"}
                },
                new Person(){Id=3, Age = 19, Dep = "UX", Name = "Сериков Берик"},
                new Person(){Id=4, Age = 33, Dep = "UX", Name = "Лебедев Артемий"},
                new Person(){Id=5, Age = 26, Dep = "DEV", Name = "Бериков Мурат"},
                new Person(){Id=6, Age = 21, Dep = "UX", Name = "Сеитова Гульмира"},
                new Person(){Id=5, Age = 30, Dep = "DEV", Name = "Сеитова Аслан"}

            };

            foreach (var person in persons)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                if (person.Dep.Equals("DEV"))
                {
                    Thread.Sleep(17);
                    string[] randomSkills = devLang.OrderBy(x=>rnd.Next()).Take(2).ToArray();
                    string str = string.Join(",",randomSkills);
                    Console.WriteLine(str);
                    person.Skills = randomSkills.ToList();
                }
            }




          
            Console.ReadLine();
        }

        static string[] Shuffle(string[] source, int n)
        {
            Random rnd = new Random();
            Thread.Sleep(18);
            var result = source.OrderBy(a => rnd.Next()).Take(n);
            return result.ToArray();
        }


    }

   
    

    class Person
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Dep { set; get; }
        public List<string> Skills { set; get; }
    }

    
}
