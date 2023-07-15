# DormitoryProject

Türkçe (Turkish):

Bu proje bir öğrenci yurdu için geliştirilebilecek bir otomasyon projesinin back-end’de istenilen işleri yapması için geliştirdiğim bir api projesidir. Aşağıdaki uri’lar ilgili verileri getirmek için kullanılabilir:

Herhangi bir entity’nin (student, admin, permission, vs.) CRUD işlemlerinin endpointleri için restful api tasarımı kullanılmıştır:
api/[entity] (GET – Hepsini getirmek için)

api/[entity]/{id} (GET – Bir tanesini getirmek için)

api/[entity] (POST, PUT, DELETE)


Login işlemi için:
api/Authentication (Post)


Logout işlemi için:
api/Authentication (GET)


Şifre değiştirmek için:
api/Authentication/changepassword (POST)


Öğrencinin event’larını getirmek için:
api/Event/geteventofstudent/{studentId} (GET)


Öğrenciyi event’a kaydetmek için:
api/event/registerstudenttoevent (POST)


Öğrenciye doğrulama kodu göndermek için:
api/confirmcode/sendconfirmcode (POST)


Öğrencinin gönderdiği kodu doğrulamak için:
api/confirmcode/confirmmail (POST)


Belirli bir taksidi ödeyen öğrencileri getirmek için:
api/payment/getpaidstudentsofmonths/{monthId} (GET)


Bir öğrencinin ödediği taksitleri getirmek için:
api/payment/getpaymentsofstudent/{studentId} (GET)


Öğrencinin ödemesini kaydetmek için:
api/payment (POST)


Öğrencinin izin kayıtlarını getirmek için:
api/permission/gerpermissionsofstudent/{studentId} (GET)


Odada kalan öğrencileri getirmek için:
api/room/student/{RoomId} (GET)


Bütün öğrencileri tavsiye-şikayetleri ile birlikte getirmek için:
api/student/getstudentswithsuggestions (GET)


Bir öğrenciyi tavsiye-şikayetiyle birlikte  getirmek için:
api/student/getstudentwithsuggestions/{studentId} (GET)


Bütün öğrencileri izin kayıtları ile birlikte getirmek için:
api/student/getstudentswithpermissions (GET)


Bir öğrenciyi izin kayıtlarıyla birlikte getirmek için:
api/student/getstudentwithpermissions/{studentId} (GET)


Bir event’ın katılımcılarını getirmek için:
api/student/getparticipantsofevent (GET)


Bir öğrencinin tavsiye-şikayetlerini getirmek için:
api/suggestion/getsuggestionsofstudent/{studentId} (GET)



Bu proje bir back-end projesidir. Front-end taradında bir çalışma yapılmamış ve herhangi bir kullancı arayüzü tasarlanmamıştır. Swagger ve postman araçları ile uri'ler test edilmiştir. İncelediğiniz için teşekkürler...




English (İngilizce):

Hello. This is an api project for fulfilling the expected tasks of back-end of an otomation project developed for an student dormitory. The uri’s below can be used to fulfill the related tasks.

Restful API design is used for endpoints of CRUD processes of any entity (student, admin, permission, vs.):
api/[entity] (GET – To get all of them)

api/[entity]/{id} (GET – To get one of them)

api/[entity] (POST, PUT, DELETE)


To login:
api/Authentication (Post)


To logout :
api/Authentication (GET)


To change password:
api/Authentication/changepassword (POST)


To get events of a student:
api/Event/geteventofstudent/{studentId} (GET)


To register a student to an event:
api/event/registerstudenttoevent (POST)


To send confirm code to the student:
api/confirmcode/sendconfirmcode (POST)


To confirm the code that student sent:
api/confirmcode/confirmmail (POST)


To get students who paid the particular installment:
api/payment/getpaidstudentsofmonths/{monthId} (GET)


To get installments that a student paid:
api/payment/getpaymentsofstudent/{studentId} (GET)


To save the payment of a student:
api/payment (POST)


To get permission records of a student:
api/permission/gerpermissionsofstudent/{studentId} (GET)


To get students who is in a room:
api/room/student/{RoomId} (GET)


To get all of the students with their suggesitons-complaints:
api/student/getstudentswithsuggestions (GET)


To get one of the students with his/her suggesitons-complaints:
api/student/getstudentwithsuggestions/{studentId} (GET)


To get all of the students with their permissions:
api/student/getstudentswithpermissions (GET)


To get one of the students with his/her permissions:
api/student/getstudentwithpermissions/{studentId} (GET)


To get the participants of an event:
api/student/getparticipantsofevent (GET)


To get the suggestion-complaints of a student:
api/suggestion/getsuggestionsofstudent/{studentId} (GET)



This is a back-end project. There are no works for front-end and no user interface is designed. Uri's are tested using swagger and postman tools. Thank you to examine...
