/*
Simple script to monitoring connect system call for IPV4 of TCP and UDP
Based on a book Attacking Network Protocols -James Forshaw
Write by Josfres

Usage: dtrace -s traceconnect.d
*/


struct sockaddr_in{

    short           sin_family;     //AF_INET_V4
    unsigned short  sin_port;       //PORT   
    in_addr_t       sin_addr;       //IP
    char            sin_zero[8];    //NO_POSIX  
};

syscall::connect:entry
arg2 == sizeof(struct sockaddr_in)
{
    addr=(struct sockaddr_in*)copyin(arg1,arg2);
    printf("Process: '%s' %s:%d",execname,inet_ntop(2,&addr->sin_addr),ntohs(addr->sin_port));
}