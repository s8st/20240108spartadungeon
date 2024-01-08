







namespace _20240108spartadungeon
{
    public class Character
    {

        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }

    }

    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int Type { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public bool IsEquipped { get; set; }

        public static int ItemCnt = 0;

        public Item(string name,string description,int type,int atk, int def,int hp, bool isEquipped=false )
        {
           Name=name;
            Description=description;
            Type=type;
            Atk=atk;
            Def=def;
            Hp = hp;
            IsEquipped = isEquipped;

        }
        public void PrintItemStatDescription(bool withNumber=false,int idx=0)
        {
            Console.WriteLine("- ");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{idx}");
                Console.ResetColor();

            }
            if (IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 9));
            }

            else Console.Write(PadRightForMixedText(Name,12));
           
                Console.Write(" | ");

                if (Atk != 0) Console.Write($"Atk{(Atk>=0?"+":"")}{Atk}");
                if (Def != 0) Console.Write($"Def{(Def >= 0 ? "+" : "")}{Def}");
                if (Hp != 0) Console.Write($"Hp{(Hp >= 0 ? "+" : "")}{Hp}");

                Console.Write("|");
                Console.WriteLine(Description);


            


        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach(char c in str)
            {
                if(char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; //한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1; //나머지 문자에 대해 길이를 1로 취급
                }
               
            }
            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);

        }


    }

    internal class Program
    {
        static Character _player;
        static Item[] _items;



        static void Main(string[] args)
        {
            // 구성
            // 0. 데이터 초기화
            // 1. 스타팅 로고를 보여줌(게임 처음 켤때만 보여줌)
            // 2. 선택 화면을 보여줌(기본 구현사항- 상태/인벤토리)
            // 3. 상태화면을 구현함( 필요 구형 요소: 캐릭터, 아이템)
            // 4. 인벤토리 화면 구현함
            // 4-1. 장비 장착 화면 구현
            // 5. 선택화면 확장

            //왜 GameDadaSetting을 만들지??
            // 클래스 위치를 왜 메인함수 밖으로? program 밖으로?

            GameDataSetting();
            PrintStartLogo();
            StartMenu();

        }

        private static void StartMenu()
        {
            // 구성
            // 0. 화면 정리
            // 1. 선택 멘트를 줌
            // 2. 선택 결과값을 검증함
            // 3. 선택 결과에 따라 메뉴로 보내줌
            Console.Clear();

            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine();

            //int keyInput = int.Parse(Console.ReadLine());
            switch (CheckValidInput(1, 2))
            {
                case 1:
                    StatusMenu();
                    break;
                    case 2:
                    Inventory();
                    break;

            }


        }

        private static void Inventory()
        {
            Console.Clear();

            ShowHighlightedText("■ 인벤토리 ■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for(int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription();
            }
            //Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("0.나가기");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine();

            switch (CheckValidInput(0, 1))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;

            }


        }

        private static void EquipMenu()
        {
            Console.Clear();

            ShowHighlightedText("■ 인벤토리-장착 관리 ■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription(true,i+1);
            }
            //Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("0.나가기");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine();

            int keyInput = CheckValidInput(0, Item.ItemCnt);

            switch (keyInput)
            {
                case 0:
                    Inventory();
                    break;
                default :
                    ToggleEquipStatus(keyInput - 1); // 유저가 입력하는 건 1,2,3, :tlfwp qoduf  0,1,2...
                    EquipMenu();
                    break;

            }


        }

        private static void ToggleEquipStatus(int idx)
        {
            _items[idx].IsEquipped = !_items[idx].IsEquipped;
        }

        private static void StatusMenu()
        {

            Console.Clear();

            ShowHighlightedText("■ 상태 보기 ■");
            Console.WriteLine("캐릭터의 정보가 표기됩니다");

            PrintTextWithHighlights("Lv. ",_player.Level.ToString("00")); //두자리수로 표기
            Console.WriteLine("");
            Console.WriteLine("{0}({1})",_player.Name,_player.Job);

            int bonusAtk = getSumBonusAtk();
            int bonusDef = getSumBonusDef();
            int bonusHp = getSumBonusHp();

            PrintTextWithHighlights("공격력 : ", (_player.Atk+bonusAtk).ToString(), bonusAtk >0 ? string.Format($"(+{bonusAtk})") : "");
            PrintTextWithHighlights("방어력 : ", (_player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format($"(+{bonusDef})") : "");
            PrintTextWithHighlights("체력 : ", (_player.Atk + bonusHp).ToString(), bonusHp > 0 ? string.Format($"(+{bonusHp})") : "");
            PrintTextWithHighlights("골드 : ", _player.Gold.ToString());

            Console.WriteLine("");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");
           
            switch (CheckValidInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
                

            }

        }

        private static int getSumBonusAtk()
        {
            int sum = 0;
            for (int i= 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Atk;
            }
            return sum;
        }
        private static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Def;
            }
            return sum;
        }
        private static int getSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Hp;
            }
            return sum;
        }



        private static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();


        }
        private static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1); 
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write(s2);
            //Console.Clear();
            Console.ResetColor();
            Console.WriteLine(s3);
        }




        private static int CheckValidInput(int min, int max)
        {
            // 설명
            // 아래 두가지 상황은 비정상 -> 재입력 수행
            // (1) 숫자가 아닌 입력을 받은 경위
            // (2) 숫자가 최솟값-최댓값의 범위를 넘는 경우

            int keyInput;
            bool result;
            do
            {
                Console.WriteLine("원하시는 행동을 입력하세요");
                result = int.TryParse( Console.ReadLine(), out keyInput);
            }while (result==false || CheckIfValid(keyInput,min,max)==false);

            //제대로 입력을 받았다는 뜻
            return keyInput;

        }

        private static bool CheckIfValid(int keyInput, int min, int max)
        {
            if(min<=keyInput &&keyInput<=max) return true;
            return false;
        }

        private static void PrintStartLogo()
        {

            //Console.WriteLine($"" +
            //    $"                                                                                          \r\n                 ▄████████    ▄███████▄    ▄████████    ▄████████     ███        ▄████████   \r\n                ███    ███   ███    ███   ███    ███   ███    ███ ▀█████████▄   ███    ███   \r\n                ███    █▀    ███    ███   ███    ███   ███    ███    ▀███▀▀██   ███    ███   \r\n                ███          ███    ███   ███    ███  ▄███▄▄▄▄██▀     ███   ▀   ███    ███   \r\n              ▀███████████ ▀█████████▀  ▀███████████ ▀▀███▀▀▀▀▀       ███     ▀███████████   \r\n                       ███   ███          ███    ███ ▀███████████     ███       ███    ███   \r\n                 ▄█    ███   ███          ███    ███   ███    ███     ███       ███    ███   \r\n               ▄████████▀   ▄████▀        ███    █▀    ███    ███    ▄████▀     ███    █▀    \r\n                                                       ███    ███                            \r\n              ████████▄  ███    █▄  ███▄▄▄▄      ▄██████▄     ▄████████  ▄██████▄  ███▄▄▄▄   \r\n              ███   ▀███ ███    ███ ███▀▀▀██▄   ███    ███   ███    ███ ███    ███ ███▀▀▀██▄ \r\n              ███    ███ ███    ███ ███   ███   ███    █▀    ███    █▀  ███    ███ ███   ███ \r\n              ███    ███ ███    ███ ███   ███  ▄███         ▄███▄▄▄     ███    ███ ███   ███ \r\n              ███    ███ ███    ███ ███   ███ ▀▀███ ████▄  ▀▀███▀▀▀     ███    ███ ███   ███ \r\n              ███    ███ ███    ███ ███   ███   ███    ███   ███    █▄  ███    ███ ███   ███ \r\n              ███   ▄███ ███    ███ ███   ███   ███    ███   ███    ███ ███    ███ ███   ███ \r\n              ████████▀  ████████▀   ▀█   █▀    ████████▀    ██████████  ▀██████▀   ▀█   █▀  \r\n                                                                                            " +
            //    $"");




            Console.WriteLine("  ___________________   _____  __________ ___________ _____                 \r\n /   _____/\\______   \\ /  _  \\ \\______   \\\\__    ___//  _  \\                \r\n \\_____  \\  |     ___//  /_\\  \\ |       _/  |    |  /  /_\\  \\               \r\n /        \\ |    |   /    |    \\|    |   \\  |    | /    |    \\              \r\n/_______  / |____|   \\____|__  /|____|_  /  |____| \\____|__  /              \r\n        \\/                   \\/        \\/                  \\/               \r\n                                                                            \r\n________    ____ ___ _______     ________ ___________________    _______    \r\n\\______ \\  |    |   \\\\      \\   /  _____/ \\_   _____/\\_____  \\   \\      \\   \r\n |    |  \\ |    |   //   |   \\ /   \\  ___  |    __)_  /   |   \\  /   |   \\  \r\n |    `   \\|    |  //    |    \\\\    \\_\\  \\ |        \\/    |    \\/    |    \\ \r\n/_______  /|______/ \\____|__  / \\______  //_______  /\\_______  /\\____|__  / \r\n        \\/                  \\/         \\/         \\/         \\/         \\/  \r\n                                                                            ");

            Console.ReadKey();
        }

        private static void GameDataSetting()
        {
            _player = new Character("chad", "전사", 1, 10, 5, 100, 1500);
            _items = new Item[10];
            AddItem(new Item("무쇠갑옷","무쇠로 만들어져 튼튼한 갑옵입니다.",0,0,5,0));
            AddItem(new Item("낡은 검","쉽게 볼 수 있는 낡은 검입니다",1,2,0,0));
        }

        static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10) return;
            _items[Item.ItemCnt] = item; //0개 ->0번 인덱스/ 1개 ->1번 인덱스
            Item.ItemCnt++;
        }

    }



}

