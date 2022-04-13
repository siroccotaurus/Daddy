using System;
using System.IO;

namespace DungeonsAndDragonsWeb.Models.Resources
{
    static class ImageHandler
    {
        public const string PATH = "/images/non-static/";
        public static void Init(Type type)
        {
            if (!Directory.Exists(PATH)) Directory.CreateDirectory(PATH);
            if (!Directory.Exists(PATH + type.Name)) Directory.CreateDirectory(PATH + type.Name);
        }
        public static void Init(Type[] types) { foreach (Type t in types) Init(t); }

        public static string Get(Type type, string name) => Directory.Exists(PATH + type.Name) ? PATH + type.Name + "/" + name + ".png" : throw new ImageHandlerException("Directory not initialized!");
        public static string Get(Type type, int id) => Get(type, id.ToString());
        public static bool Set(Type type, string name)
        {
            return true;
        }
        public static bool Exists(Type type) => Directory.Exists(PATH) && Directory.Exists(PATH + type.Name);
    }

    public class ImageHandlerException : Exception
    {
        public ImageHandlerException() { }
        public ImageHandlerException(string message) : base(message) { }
        public ImageHandlerException(string message, Exception inner) : base(message, inner) { }
    }
}
