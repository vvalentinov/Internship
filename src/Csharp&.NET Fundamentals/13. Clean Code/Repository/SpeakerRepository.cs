using _13._Clean_Code.Models;

namespace _13._Clean_Code.Repository;

public class SpeakerRepository : ISpeakerRepository
{
    private readonly List<Speaker> _speakers = [];

    /// <summary>
    /// Add's a speaker and returns the new speaker's id.
    /// </summary>
    public int AddSpeaker(Speaker speaker)
    {
        _speakers.Add(speaker);
        return _speakers.Count;
    }

    /// <summary>
    /// Deletes a speaker and returns the id.
    /// If the speaker is not present, it will return 0.
    /// </summary>
    public int DeleteSpeaker(Speaker speaker)
    {
        var speakerIndex = _speakers.IndexOf(speaker);

        if (speakerIndex == -1)
        {
            return 0;
        }

        _speakers.Remove(speaker);

        return speakerIndex + 1;
    }

    /// <summary>
    /// Returns the speaker with the provided id.
    /// If the speaker with the provided id is not present, it will return null.
    /// </summary>
    public Speaker? GetSpeakerById(int speakerId)
        => _speakers.FirstOrDefault(x => x.Id == speakerId);

    /// <summary>
    /// Updates the speaker.
    /// If the speaker with the this id is not present, it will return null.
    /// </summary>
    public Speaker? UpdateSpeaker(Speaker speaker)
    {
        var index = _speakers.FindIndex(x => x.Id == speaker.Id);

        if (index == -1)
        {
            return null;
        }

        _speakers[index] = speaker;

        return speaker;
    }

    public List<Speaker> GetAllSpeakers() => _speakers;
}
