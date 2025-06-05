# Sistem Parkir

Sistem manajemen tempat parkir berbasis command-line yang dibangun dengan .NET 9.0. Aplikasi ini membantu mengelola kendaraan parkir dengan berbagai fitur seperti memarkir, mengeluarkan, dan menanyakan informasi kendaraan.

## Fitur

- Membuat tempat parkir dengan jumlah slot tertentu
- Memarkir kendaraan (Mobil/Motor) dengan nomor registrasi dan warna
- Mengosongkan slot parkir
- Melihat status tempat parkir
- Mencari kendaraan berdasarkan tipe, warna, dan nomor registrasi
- Menemukan kendaraan dengan plat nomor ganjil/genap

## Struktur Proyek

```
ParkingSystem/
├── Models/
│   ├── ParkingLot.cs    # Model untuk slot parkir
│   └── Vehicle.cs       # Model kendaraan
├── Services/
│   └── ParkingService.cs  # Logika utama sistem parkir
├── Program.cs           # Antarmuka command-line
└── README.md           # File ini
```

## Model

### Vehicle.cs
Merepresentasikan kendaraan dengan properti:
- RegistrationNumber: Nomor registrasi kendaraan
- Type: Jenis kendaraan (Mobil/Motor)
- Color: Warna kendaraan

### ParkingLot.cs
Merepresentasikan slot parkir dengan:
- SlotNumber: Nomor slot
- Vehicle: Kendaraan yang diparkir (bisa null)
- IsOccupied: Status apakah slot terisi

## Perintah

1. **Buat Tempat Parkir**
   ```
   create_parking_lot <jumlah_slot>
   ```
   Membuat tempat parkir dengan jumlah slot yang ditentukan.

2. **Parkir Kendaraan**
   ```
   park <nomor_registrasi> <warna> <tipe>
   ```
   Memarkir kendaraan di slot yang tersedia.
   - `tipe` harus "Mobil" atau "Motor"

3. **Keluarkan Kendaraan**
   ```
   leave <nomor_slot>
   ```
   Mengosongkan slot parkir yang ditentukan.

4. **Cek Status**
   ```
   status
   ```
   Menampilkan status semua slot parkir.

5. **Cari Berdasarkan Tipe**
   ```
   type_of_vehicles <tipe>
   ```
   Menghitung jumlah kendaraan berdasarkan tipe.

6. **Cari Berdasarkan Warna**
   ```
   registration_numbers_for_vehicles_with_colour <warna>
   slot_numbers_for_vehicles_with_colour <warna>
   ```
   Mencari kendaraan berdasarkan warna.

7. **Cari Berdasarkan Nomor Registrasi**
   ```
   slot_number_for_registration_number <nomor_registrasi>
   ```
   Mencari slot parkir berdasarkan nomor registrasi kendaraan.

8. **Cari Berdasarkan Jenis Plat**
   ```
   registration_numbers_for_vehicles_with_odd_plate
   registration_numbers_for_vehicles_with_even_plate
   ```
   Mencari kendaraan dengan plat nomor ganjil atau genap.

## Memulai

1. Pastikan [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) sudah terinstall
2. Clone repositori ini
3. Masuk ke direktori proyek
4. Jalankan aplikasi:
   ```
   dotnet run
   ```
5. Gunakan perintah-perintah yang tersedia untuk berinteraksi dengan sistem

## Contoh Penggunaan

```
create_parking_lot 3
park B-1234-ABC Hitam Mobil
park B-1235-XYZ Putih Motor
status
leave 2
status
registration_numbers_for_vehicles_with_colour Hitam
```

## Penanganan Error

Aplikasi ini memiliki penanganan error untuk:
- Perintah tidak valid
- Tempat parkir penuh
- Slot tidak tersedia
- Tipe kendaraan tidak valid
- Pengecekan null reference

## Ketergantungan

- .NET 9.0 Runtime
- Tidak membutuhkan paket NuGet eksternal

## Lisensi

Proyek ini bersifat open source dan tersedia di bawah [Lisensi MIT](LICENSE).
