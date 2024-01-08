using System.Xml.Serialization;
//...


namespace spartadungeon20240105
{
    internal class spartadungeon20240105
    {
        public class MainStartInfo
        {
            public void Choice()
            {
                Console.WriteLine
               ($"스파르타 마을에 오신 여러분 환영합니다.\r\n" +
               $"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n\r\n" +
               $"1.상태 보기\r\n" +
               $"2.인벤토리\r\n" +
               $"3.상점\r\n\r\n" +
               $"원하시는 행동을 입력해주세요.\r\n " +
               $"◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆\n" +
               $">>");
                //\r : 맨 앞줄로 이동으로 다음 입력글이 있으면 덮어 써버린다.
                //\r\n : 맨 앞줄로 이동하고 다음줄로 이동
                //\b: 앞으로 한칸 이동. 이것도 앞에 글자나 공백이 있으면 지워버린다
                //\t : 8칸 삽입

            }
        }
        struct CharacterInfo
        {
            public int lv =01;
            public string name="길동";
            public string job = "전사";
            public int attack = 10;
            public int defense = 5;
            public int strength = 100;
            public int gold = 1500;

            public CharacterInfo()
            {

            }

            public void CInfo()
            {
                Console.WriteLine
                    ($" 상태 보기\r\n" +
                    $"캐릭터의 정보가 표시됩니다.\r\n\r\n" +
                    $"Lv. {lv}      \r\n" +
                    $"{name}({job} )\r\n" +
                    $"공격력 : {attack}\r\n" +
                    $"방어력 : {defense}\r\n" +
                    $"체 력 : {strength}\r\n" +
                    $"Gold : {gold} G\r\n\r\n" +
                    $"0. 나가기\r\n\r\n" +
                    $"원하시는 행동을 입력해주세요.\r\n" +
                    $">>");

            }

           

        }
        public class InventoryInfo
        {
            public void PrintInventory()
            {
                Console.WriteLine
                    ($"인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n" +
                    $"[아이템 목록]\r\n\r\n" +
                    $"1. 장착 관리\r\n" +
                    $"0. 나가기\r\n\r\n" +
                    $"원하시는 행동을 입력해주세요.\r\n>>");
            }
            public void PrintInventoryInfo2()
            {
                Console.WriteLine
                    ($"인벤토리\r\n" +
                    $"보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n" +
                    $"[아이템 목록]\r\n" +
                    $"- [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.\r\n" +
                    $"- [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.\r\n" +
                    $"- 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.\r\n\r\n" +
                    $"1. 장착 관리\r\n2. 나가기\r\n\r\n" +
                    $"원하시는 행동을 입력해주세요.\r\n" +
                    $">>");
            }

        }
        public class StoreInfo
        {

        }

        static void Main(string[] args)
        {
            MainStartInfo info = new MainStartInfo();
            info.Choice();   //메인화면 클래스를 만들어서 시작화면 호출



           
            
            //CharacterInfo characterInfo; 
            CharacterInfo characterInfo = new CharacterInfo();
            



            //// <원하는 행동의 숫자를 타이핑하면 실행합니다.>
            //// <1 ~3 이외 입력시 -잘못된 입력입니다 출력>

            // 참고 : 사전 기초문법 연습문제 3-1. 입력받은 데이터가 숫자인지 문자열인지 판단

            while ( true )
            {
                

                // int userInputEnterDungeon = int.Parse( Console.ReadLine() );    
                string userInputEnterDungeon = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(userInputEnterDungeon, out num);


                if (isInt)
                {
                    //if (num >= 1 && num <= 3)
                    //{
                    //    Console.WriteLine($"입력한 번호는 : {num} --->");
                    //}
                    switch (num)
                    {
                        //case 1: Console.WriteLine("1.상태 보기\n{0}", characterInfo.CInfo()); break;
                        //case 1: Console.WriteLine($"1.상태 보기\n{characterInfo.CInfo()}" ); break;
                        case 1:
                            Console.WriteLine($"1.상태 보기\n");
                            characterInfo.CInfo();
                           
                            //string userInputCInfo = Console.ReadLine();
                            //int numCInfo;
                            //bool isIntCInfo = int.TryParse(userInputCInfo, out numCInfo);
                           
                            //if (isIntCInfo && numCInfo ==0)
                            //{
                            //    info.Choice();
                            //}
                            
                                
                                break;
                        case 2: 
                            Console.WriteLine("2.인벤토리\n"); 
                            break;
                        case 3: 
                            Console.WriteLine("3.상점\n"); 
                            break;
                        default: 
                            Console.WriteLine("-잘못된 입력입니다 1~3 사이에서 입력하라\n"); 
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("-잘못된 입력입니다\n");

                }

              // break;
            }



       



        }
    }
}
