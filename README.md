# Sistem Parkir

Sistem manajemen tempat parkir berbasis command-line yang dibangun dengan .NET 9.0. Aplikasi ini merupakan jawaban dari tugas yang diberikan dari NTT Indonesia Technology.
- Nama: Saeful Ismail
- Github: https://github.com/saefulismail01
- LinkedIn: https://www.linkedin.com/in/saefulismail

## Perintah pada aplikasi ini

| Perintah | Deskripsi | Contoh |
|----------|-----------|--------|
| `create_parking_lot <jumlah_slot>` | Membuat tempat parkir dengan jumlah slot tertentu | `create_parking_lot 6` |
| `park <nomor_plat> <warna> <tipe>` | Memarkir kendaraan | `park B-1234-XYZ Putih Mobil` |
| `leave <nomor_slot>` | Mengosongkan slot parkir | `leave 4` |
| `status` | Menampilkan status parkir saat ini | `status` |
| `type_of_vehicles <tipe>` | Menghitung jumlah kendaraan berdasarkan tipe | `type_of_vehicles Motor` |
| `registration_numbers_for_vehicles_with_ood_plate` | Menampilkan nomor plat ganjil | `registration_numbers_for_vehicles_with_ood_plate` |
| `registration_numbers_for_vehicles_with_event_plate` | Menampilkan nomor plat genap | `registration_numbers_for_vehicles_with_event_plate` |
| `registration_numbers_for_vehicles_with_colour <warna>` | Mencari kendaraan berdasarkan warna | `registration_numbers_for_vehicles_with_colour Putih` |
| `slot_numbers_for_vehicles_with_colour <warna>` | Mencari slot parkir berdasarkan warna kendaraan | `slot_numbers_for_vehicles_with_colour Putih` |
| `slot_number_for_registration_number <nomor_plat>` | Mencari slot parkir berdasarkan nomor plat | `slot_number_for_registration_number B-1234-XYZ` |
| `exit` | Keluar dari aplikasi | `exit` |

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
   dotnet run
   ```

3. Gunakan perintah-perintah yang tersedia untuk berinteraksi dengan sistem

### Contoh interaksi sesuai dengan contoh yang diberikan

```bash
# Membuat tempat parkir dengan 6 slot
create_parking_lot 6

# Memarkir kendaraan
park B-1234-XYZ Putih Mobil
park B-9999-XYZ Putih Motor

# Melihat status parkir
status

# Mencari kendaraan berdasarkan warna
registration_numbers_for_vehicles_with_colour Putih

# Keluar dari aplikasi
exit
```

## Contoh Penggunaan Lengkap

Berikut adalah contoh penggunaan lengkap sistem parkir sesuai dengan skenario yang diminta:

```bash
# Membuat tempat parkir dengan 6 slot
create_parking_lot 6

# Memarkir beberapa kendaraan
park B-1234-XYZ Putih Mobil
park B-9999-XYZ Putih Motor
park D-0001-HIJ Hitam Mobil
park B-7777-DEF Red Mobil
park B-2701-XXX Biru Mobil
park B-3141-ZZZ Hitam Motor

# Mengosongkan slot nomor 4
leave 4

# Melihat status terkini
status

# Memarkir kendaraan baru di slot yang kosong
park B-333-SSS Putih Mobil

# Menghitung jumlah kendaraan berdasarkan tipe
type_of_vehicles Motor
type_of_vehicles Mobil

# Mencari kendaraan dengan nomor plat ganjil/genap
registration_numbers_for_vehicles_with_ood_plate
registration_numbers_for_vehicles_with_event_plate

# Mencari kendaraan berdasarkan warna
registration_numbers_for_vehicles_with_colour Putih

# Mencari slot parkir berdasarkan warna kendaraan
slot_numbers_for_vehicles_with_colour Putih

# Mencari slot parkir berdasarkan nomor plat
slot_number_for_registration_number B-3141-ZZZ
slot_number_for_registration_number Z-1111-AAA
```

## Format Output

### Status Parkir
```
Slot    Registration No    Type    Colour
1       B-1234-XYZ         Mobil   Putih
2       B-9999-XYZ         Motor   Putih
3       D-0001-HIJ         Mobil   Hitam
```

### Pesan Konfirmasi
- Saat memarkir: `Allocated slot number: X`
- Saat mengosongkan: `Slot number X is free`
- Pencarian tidak ditemukan: `Not found`


## Dependensi

- .NET 9.0 Runtime