tinymce.init({
    selector: '#editor',
    height: 300
});

Dropzone.autoDiscover = false;
new Dropzone("#dropzone", {
    url: "/Content/Upload",
    maxFiles: 5
});

const autocomplete = new google.maps.places.Autocomplete(
    document.getElementById("address")
);

Sortable.create(document.getElementById("sortableList"), {
    animation: 150,
    onEnd: () => {
        
    }
});

let cropper;
document.getElementById("imageInput").addEventListener("change", e => {
    const img = document.getElementById("preview");
    img.src = URL.createObjectURL(e.target.files[0]);

    cropper = new Cropper(img, {
        aspectRatio: 1,
        viewMode: 1
    });
});
