using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectService", menuName = "ScriptableObjects/PrefabDictionary/ProjectService", order = 1000)]
public class ProjectService : ScriptableObject
{
	[SerializeField] private List<ProjectRecord> Projects;

	[SerializeField] TextAsset CSV;

	#region Ppl
	[ContextMenu("Parse")]
	public void Parse()
	{
		string text = CSV.text;
		string[] lines = text.Split("\n");
		for (int i = 1; i < lines.Length; i++)
		{
			string[] values = lines[i].Split(',');
			ModifyOrCreateProject(values);
		}
	}

	private int FindRecord(string name)
	{
		for (int i = 0; i < Projects.Count; i++)
			if (Projects[i].Name == name)
				return i;
		return -1;
	}

	private ProjectRecord ModifyOrCreateProject(string[] values)
	{
		int index = FindRecord(values[(int)E_Filds.Project]);
		if (index == -1)
		{
			Projects.Add(new ProjectRecord() { People = new List<string>(), Stuff = new List<E_StuffType>()});
			index = Projects.Count - 1;
		}
		ProjectRecord record = Projects[index];
		Projects[index] = ModifyPerson(record, values);
		return record;
	}

	private ProjectRecord ModifyPerson(ProjectRecord record, string[] values)
	{
		record.Name = values[(int)E_Filds.Project];
		string person = values[(int)E_Filds.Name];

		if(record.People.Contains(person) == false)
			record.People.Add(person);
		return record;
	}
	#endregion
}