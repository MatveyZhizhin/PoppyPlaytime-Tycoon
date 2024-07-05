
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения
        public int Balance = 0;
        public int StackHolderCurrentSize = 0;
        public int StackHolderMaxSize = 10;
        public float PunchRate = 2f;
        public bool[] PurchasedObjects = new bool[10];
        public int[] CurrentLevelsOfUpgraders = new int[18];
        public int[] CostsOfUpgraders = new int[18];
        public float[] ProduceRates = new float[4];
        public int[] ToyCosts = new int[4];
        public float[] MineRates = new float[4];
        public float[] MoveSpeeds = new float[8];

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
