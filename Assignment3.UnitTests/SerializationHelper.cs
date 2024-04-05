using Assignment3.Utility;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.UnitTests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers<T>(SLL<T> users, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static SLL<T> DeserializeUsers<T>(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL<T>)formatter.Deserialize(stream);
            }
        }
    }
}
