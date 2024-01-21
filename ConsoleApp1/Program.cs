
using ConsoleApp1.Datas;
using ConsoleApp1.İnterface;
using ConsoleApp1;
using Newtonsoft.Json;

var personalUsers = JsonConvert.DeserializeObject<IList<Personal>>(PersonalDatas.PersonalJson);
var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(StudentDatas.StudentJson);
var jobberUsers = JsonConvert.DeserializeObject<IList<Jobber>>(JobberDatas.JobberJson);

IDictionary<string, IList<string>> indexes = new Dictionary<string, IList<string>>();
IDictionary<string, IUserBase> fastList = new Dictionary<string, IUserBase>();

fastList.AddToDictionary(personalUsers.Select(user => (user as IUserBase)).ToList(), indexes);
fastList.AddToDictionary(studentUsers.Select(user => (user as IUserBase)).ToList(), indexes);
fastList.AddToDictionary(jobberUsers.Select(user => (user as IUserBase)).ToList(), indexes);


var findAll = FindByIndex("ejeannequin4z");
Console.WriteLine(JsonConvert.SerializeObject(findAll));
Console.WriteLine();




/*
Console.WriteLine(JsonConvert.SerializeObject(fastList));
Console.WriteLine();
*/

Console.WriteLine(JsonConvert.SerializeObject(indexes));
Console.ReadKey();


IList<IUserBase>? FindByIndex(string search)
{
    if (indexes.ContainsKey(search))
    {
        var findedKeys = indexes[search];
        return findedKeys.Select(key => fastList[key]).ToList();
    }
    return null;
}


/*
var findAll = FindByIndex("Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findAll));
*/

/*
var findedListWithPredicate = personalUsers.FindAll(user => user.FirstName == "Dugall" || user.LastName == "Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
*/