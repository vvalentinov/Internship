using _13._Clean_Code.Models;

namespace _13._Clean_Code.Repository;

public interface ISpeakerRepository
{
    int AddSpeaker(Speaker speaker);

    Speaker? GetSpeakerById(int speakerId);

    int DeleteSpeaker(Speaker speaker);

    Speaker? UpdateSpeaker(Speaker speaker);

    List<Speaker> GetAllSpeakers();
}
