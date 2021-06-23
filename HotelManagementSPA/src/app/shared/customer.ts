export interface customer {
    id: number;
    roomId: number;
    cName: string;
    address: string;
    phone: string;
    email: string;
    checkIn: Date;
    totalPersons: number;
    bookingDays: number;
    advance: number;
    message: string;
    statusCode: number;
}