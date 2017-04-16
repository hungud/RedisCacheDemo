using RedisCacheDemo;
using System;

public class ClassTest1
{
	public ClassTest1()
	{
	}

    public void a()
    {
        //create redis connection and database

        var RedisConnection = RedisConnectionFactory.GetConnection();
        var db = RedisConnection.GetDatabase();

        //string demo

        string inputStringData = "A little bit of string  data.";

        db.StringSet("StringData", inputStringData, TimeSpan.FromMinutes(1));

        string outputStringData = db.StringGet("StringData");

        db.KeyDelete("StringData");

        //integer demo

        int inputIntData = 3855;

        db.StringSet("IntData", inputIntData);

        int outputIntData = (int)db.StringGet("IntData");

        db.KeyDelete("IntData");

        //hash demo

        var redisObjectStore = new RedisObjectStore<ExampleData>(db);

        var objDataIn = new ExampleData { Reference = Guid.NewGuid(), IntegerData = 4967, StringData = "This is an example of how to store object data in a hash" };

        redisObjectStore.Save(objDataIn.Reference.ToString(), objDataIn);

        var objDataOut = redisObjectStore.Get(objDataIn.Reference.ToString());

        redisObjectStore.Delete(objDataIn.Reference.ToString());
    }

    public class ExampleData
    {
        public Guid Reference { get; set; }
        public string StringData { get; set; }
        public int IntegerData { get; set; }
    }

}
