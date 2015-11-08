using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

/// <summary>
/// JSONUtil의 요약 설명입니다.
/// </summary>
public class JSONUtil
{
    public static Hashtable GetJSONObject(HttpRequest request)
    {
        StreamReader reader = new StreamReader(request.InputStream);
        string jsonString = reader.ReadToEnd();
        return new JavaScriptSerializer().Deserialize<Hashtable>(jsonString);
    }

    public static String toStringFromJSON(Hashtable hashtable)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        return jsSerializer.Serialize(hashtable);
    }
}