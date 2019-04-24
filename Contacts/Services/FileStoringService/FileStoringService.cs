﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Foundation;

namespace Contacts.Services.FileStoringService
{
    /// <summary>
    /// Делает файловые операций
    /// </summary>
    public class FileStoringService : IFileStoringService
    {
        #region Declarations
        StorageFolder tempFolder = ApplicationData.Current.TemporaryFolder;
        #endregion

        #region Implementation of IFileStoringService
        public async Task DeleteFromLocalStorageAsync(StorageFile file)
        {
            await file.DeleteAsync();
        }

        public async Task DeleteFromTempStorageAsync(StorageFile file)
        {
            await file.DeleteAsync();
        }

#nullable enable
        //TODD: Как только сделаешь так чтобы метод GetFileAsync мог возвращать null 
        //сделай рефакторинг кода AddEditPageViewModel(обработчик события покадание формы)
        public async Task<StorageFile> GetFileAsync(StorageFolder parentFolder,
                                                     string fileName)
        {
            StorageFile nullFile; //файл который нечего не содержит нужен для того чтобы метод не возвращал null
            StorageFile expectedFile;

            if (await ApplicationData.Current.TemporaryFolder.TryGetItemAsync(fileName) != null)
                return expectedFile = await parentFolder.GetFileAsync(fileName);
            else if (await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName) == null)
                return nullFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("Stub");
            else
                return expectedFile = await parentFolder.GetFileAsync(fileName);
        }

        public async Task SaveToLocalStorageAsync(StorageFile fileToSave, string fileName)
        {
            if (await IsFileExist(ApplicationData.Current.LocalFolder, fileName))
            {
                //StorageFile fileToDelete = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

                //await fileToDelete.DeleteAsync();

                StorageFile fileToReplace = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

                await fileToSave.CopyAndReplaceAsync(fileToReplace);
            }
            else
            {
                StorageFile fileToMove = await ApplicationData.Current.TemporaryFolder.GetFileAsync(fileToSave.Name);

                await fileToMove.MoveAsync(ApplicationData.Current.LocalFolder, fileName);
            }

        }

        public async Task<StorageFile> SaveToLocalStorageAndGetFileAsync(StorageFile fileToSave,string fileName)
        {
            await SaveToLocalStorageAsync(fileToSave, fileName);

            StorageFile fileForReturn = await GetFileAsync(ApplicationData.Current.LocalFolder, fileName);

            return fileForReturn;
        }

        public async Task SaveToTempStorageAsync(StorageFile fileToSave, string fileName)
        {
            if (await IsFileExist(ApplicationData.Current.TemporaryFolder, fileName))
            {
                StorageFile fileToDelete = await ApplicationData.Current.TemporaryFolder.GetFileAsync(fileName);

                await fileToDelete.DeleteAsync();
            }

            await fileToSave.CopyAsync(ApplicationData.Current.TemporaryFolder, fileName);
        }
        #endregion

        #region Private methods
        private async Task<bool> IsFileExist(StorageFolder parentFolder, string fileName)
        {
            if (null == await parentFolder.TryGetItemAsync(fileName))
                return false;

            return true;
        }
        #endregion
    }
}
