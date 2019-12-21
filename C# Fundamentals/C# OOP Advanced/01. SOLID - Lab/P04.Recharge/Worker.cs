namespace P04.Recharge
{
    public abstract class Worker 
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public int WorkingHours
        {
            get { return this.workingHours; }
            set { this.workingHours = value; }
        }

        public abstract void Work(int hours);
    }
}