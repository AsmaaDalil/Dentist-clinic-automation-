namespace GenricClass
{
    class product<type1, type2>
    {
        public type1 id { set; get; }
        public type2 sn { set; get; }
        public product(type1 id, type2 sn)
        {
            this.id = id;
            this.sn = sn;
        }  
        public void print(ref string s1, ref string s2)
        {
            #region s1
            s1 = "id: " + id.GetType().Name + " vales id= " + id;
            #endregion
            #region s2
            s2 = "Sn: " + sn.GetType().Name + " vales Sn=" + sn;
            #endregion
        }
    }    
}
