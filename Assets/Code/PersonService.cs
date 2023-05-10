using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonService", menuName = "ScriptableObjects/PrefabDictionary/PersonService", order = 1000)]
public class PersonService : ScriptableObject
{
	[SerializeField] private List<PersonRecord> Records;

	[SerializeField] private HashSet<string> Projects;

	[SerializeField] TextAsset CSV;

	public List<PersonRecord> GetRecords()
    {
		return Records;
    }
	#region Ppl
	[ContextMenu("Parse")]
	public void Parse()
	{
		string text = CSV.text;
		string[] lines = text.Split("\n");
		for (int i = 1; i < lines.Length; i++)
		{
			string[] values = lines[i].Split(',');
			ModifyOrCreateReord(values);
		}
	}

	private int FindRecord(string name)
	{
		for (int i = 0; i < Records.Count; i++)
			if (Records[i].Name == name)
				return i;
		return -1;
	}

	private PersonRecord ModifyOrCreateReord(string[] values)
	{
		int index = FindRecord(values[(int)E_Filds.Name]);
		if (index == -1)
		{
			Records.Add(new PersonRecord());
			index = Records.Count - 1;
		}
		PersonRecord record = Records[index];
		Records[index] = ModifyPerson(record, values);
		return record;
	}

	private PersonRecord ModifyPerson(PersonRecord record, string[] values) 
	{
		record.Name = values[(int)E_Filds.Name];
		record.Title = values[(int)E_Filds.Title];
		record.Project = values[(int)E_Filds.Project];
		return record;
	}
	#endregion
}

enum E_Filds { Name = 7, Title = 6, Project = 8 }