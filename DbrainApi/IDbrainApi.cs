using System.Threading.Tasks;

namespace DbrainApi
{
    /// <summary>
    /// Методы для работы с Dbrain API.
    /// </summary>
    public interface IDbrainApi
    {
        /// <summary>
        /// Распознавание типа документа.
        /// </summary>
        /// <param name="passData">Контент файла.</param>
        /// <param name="fileExtension">Расширение файла.</param>
        string Classify(byte[] passData, string fileExtension = ".jpg");

        /// <summary>
        /// Распознавание типа документа.
        /// </summary>
        /// <param name="passData">Контент файла.</param>
        /// <param name="fileExtension">Расширение файла.</param>
        Task<string> ClassifyAsync(byte[] passData, string fileExtension = ".jpg");

        /// <summary>
        /// Распознавание полей из документа.
        /// </summary>
        /// <param name="passData">Контент файла.</param>
        /// <param name="async">Асинхронный автоматическое распознаванеи.</param>
        /// <param name="hands">С ручным распознаванием.</param>
        /// <param name="handsAsync">Асинхронное ручное распознавание.</param>
        /// <param name="fileExtension">Расширение файла.</param>
        string Recognize(byte[] passData, bool async = false, bool hands = false, bool handsAsync = false, string fileExtension = ".jpg");

        /// <summary>
        /// Распознавание полей из документа.
        /// </summary>
        /// <param name="passData">Контент файла.</param>
        /// <param name="async">Асинхронный автоматическое распознаванеи.</param>
        /// <param name="hands">С ручным распознаванием.</param>
        /// <param name="handsAsync">Асинхронное ручное распознавание.</param>
        /// <param name="fileExtension">Расширение файла.</param>
        Task<string> RecognizeAsync(byte[] passData, bool async = false, bool hands = false, bool handsAsync = false, string fileExtension = ".jpg");

        /// <summary>
        /// Получение результатов задачи.
        /// </summary>
        /// <param name="taskId">Номер задачи.</param>
        Task<string> ResultAsync(string taskId);
    }
}
