## Tạo dự án
> 1. Sử dụng editor version 2022.3.21f1.
> 2. Tạo dự án 3D mới với tên bất kì (hoặc the-last-hope-post-apocalyptic).
> 3. Tạo clone.
> 4. Copy tất cả các tệp, thư mục trong dự án mới (ở 2.) vô dự án clone. "SKIP" các file bị trùng.
> 5. Xong.

## Lưu ý
> - Import các asset vô dự án thì nhớ kéo vô trong thư mục ImportedAssets. (Ưu tiên đồ họa low poly - nhẹ)
> - Dùng tài nguyên nào từ imported asset thì kéo tài nguyên nớ ra khỏi imported rồi bỏ vô trong các thư mục của dự án (loại tài nguyên ~ tên thư mục. Nếu chưa có tên thư mục phù hợp thì tạo thêm).
> - Nếu các imported asset cần cho các thành viên khác tham khảo thì viết tên tài nguyên vô file /Asset/References.txt.

## Work flow
> - Mỗi người tạo một nhánh riêng trên repo. Phát triển tính năng rồi đẩy lên nhánh riêng của mình (Hoàn thành thì mới đẩy lên):
>     - git checkout -b feature/{name}       : Tạo nhánh mới.
>     - Thực hiện thay đổi ... sau đó add, commit.
>     - git push -u origin feature/{name}    : Tự động tạo nhánh mới trên repo và đồng thời đẩy data lên nhánh mới.
> - Hoàn thành 1 tính năng thì tạo pull request trên repo:
>     - Bấm vô tab Pull requests trên repo.
>     - Chọn New pull request.
>     - Chọn base: Nhánh muốn merge, compare: nhánh tính năng của thành viên.
>     - Chọn Create pull request.
>     - Nhập tiêu đề. Ví dụ: "Add respawn feature".
>     - Chọn Create pull request.
>     - Chờ duyệt (Không tự merge)
