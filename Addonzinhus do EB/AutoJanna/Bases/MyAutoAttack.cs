using EloBuddy;

namespace AutoJanna.Bases
{
   public class MyAutoAttack
   {
       public AIHeroClient Target;
       public AIHeroClient Sender;

       public MyAutoAttack(AIHeroClient target, AIHeroClient sender)
       {
           Target = target;
           Sender = sender;
       }
   }
}
