namespace APBD_1;
public interface IHazardNotifier
{
    void Notify(string containerNumber, string message);
    void Notify(string message);
}