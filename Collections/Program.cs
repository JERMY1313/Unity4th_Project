using System.Security.Principal;

namespace Collections
{
    enum ItemID
    {
        RedPotion = 20,
        BluePotion = 21,
    }
    class SloatData : IComparable<SloatData>
    {
        public bool isEmpty => id == 0 && num == 0;

        public int id;
        public int num;

        public SloatData(int id, int num)
        {
            this.id = id;
            this.num = num;
        }

        public int CompareTo(SloatData? other)
        {
            return this.id == other?.id && this.num == other?.num? 0: 1;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray Inventory = new MyDynamicArray();

            for (int i = 0; i < 10; i++)
            {
                Inventory.Add(new SloatData(0, 0));

                Console.WriteLine($"슬롯 {i} : [{(ItemID)((SloatData)Inventory[i]).id}], [{((SloatData)Inventory[i]).num}]");
            }

            Inventory[0] = new SloatData((int)ItemID.RedPotion, 40);
            Inventory[1] = new SloatData((int)ItemID.BluePotion, 99);
            Inventory[2] = new SloatData((int)ItemID.BluePotion, 40);

            Console.WriteLine($"인벤토리 정보 :");
            for(int i = 0; i< Inventory.Count; i++)
            {
                Console.WriteLine($"슬롯 {i} : [{(ItemID)((SloatData)Inventory[i]).id}], [{((SloatData)Inventory[i]).num}]");
            }
            //todo -> 파란포션 5개를 획득
            //1. 파란포션 5개가 들어갈 수 있는 슬롯을 찾아야함.
            int availableSloatIndex = Inventory.FindIndex(sloatData => ((SloatData)sloatData).isEmpty || (((SloatData)sloatData).id == (int)ItemID.BluePotion && ((SloatData)sloatData).num <= 99 - 5));
            //2. 해당 슬롯의 아이템 갯수에다가 내가 추가하려는 갯수를 더한 만큼의 수정예상값을 구함
            int expected = ((SloatData)Inventory[availableSloatIndex]).num + 5;
            //3. 새로운 아이템 데이터를 만들어서 슬롯데이터를 교체해줌
            SloatData newSloatData = new SloatData((int)ItemID.BluePotion, expected);
            Inventory[availableSloatIndex] = newSloatData;


            MyDynamicArray<SloatData> inventory2 = new MyDynamicArray<SloatData>();
            //숙제 해올것.

            /*
            inventory[1] = "철수";
            Console.WriteLine($"동적배열의 0번째 인덱스 값 : {inventory[0]}");

            int idx = inventory.FindIndex(x => (string)x == "철수");
            idx = inventory.FindIndex(x => (int)x > 3);

            int 파란포션5개추가가능한인덱스 = inventory.FindIndex(x => x.isEmpty == true ||
                                                                (x.id == 파란포션아이디 &&
                                                                 x.num <= 파란포션최대갯수 - 5))
            int 수정될갯수 = inventory[파란포션5개추가가능한인덱스].num + 5;
            슬롯데이터 수정될슬롯데이터 = new 슬롯데이터(파란포션아이디, 수정될갯수);
            inventory[파란포션5개추가가능한인덱스] = 수정될슬롯데이터;
            */
        }
    }
}