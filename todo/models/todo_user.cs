namespace todo
{
    public class todo_user
    {
        public int tid { get; set; }
        public string task_area { get; set; }
        public string img_url { get; set; }
        public string status { get; set; }
    }

    public class rmTask
    {
        public int id { get; set; }
        public int tsid { get; set; }
    }

    public class upTask
    {
        public int id { get; set; }
        public int tsid { get; set; }
    }

    public class upTitle
    {
        public int id { get; set; }
        public int tsid { get; set; }
        public string tit { get; set; }
        public string img { get; set; }
    }
    

    public class AddTask
    {
        public int id { get; set; }
        public string tit { get; set; }
        public string i_url { get; set; }
        public string state { get; set; }
    }

    public class GetTask
    {
        public int tid { get; set; }
        public string title { get; set; }
        public object img_url { get; set; }
        public string status { get; set; }
    }


}