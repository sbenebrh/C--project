namespace BL
{
    public class FactoryBL
    {
        //creating a factory singleton so we get only one instanse of BL
     //   private static IBL instance = null;
      
        public static IBL GetBL()
        {
            return new myBL();
        }
    }
}
