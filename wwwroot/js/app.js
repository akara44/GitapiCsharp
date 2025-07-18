
    function toggleRepos() {
        const hiddenRepos = document.querySelectorAll('.hidden-repo');
        const button = document.getElementById('show-more-btn');

        hiddenRepos.forEach(repo => {
            const isHidden = repo.style.display === 'none' || repo.style.display === '';
            repo.style.display = isHidden ? 'flex' : 'none';
            repo.style.flexDirection = 'column';
        });

        const showing = hiddenRepos[0].style.display === 'flex';
        button.textContent = showing ? 'Daha Az' : 'Daha Fazla';
    }
